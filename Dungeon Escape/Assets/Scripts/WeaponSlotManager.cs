using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlotManager : MonoBehaviour
{
    WeaponHolderSlot leftHandSlot;
    WeaponHolderSlot rightHandSlot;

    DamageCollider leftHandDamageCollider, rightHandDamageCollider;

    public WeaponItem attackingWeapon;

    Animator anim;

    QuickSlotsUI quickSlotsUI;
    PlayerStats playerStats;

    private void Awake()
    {
        WeaponHolderSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponHolderSlot>();
        anim = GetComponent<Animator>();
        quickSlotsUI = FindObjectOfType<QuickSlotsUI>();
        playerStats = GetComponentInParent<PlayerStats>();

        foreach (WeaponHolderSlot weaponSlot in weaponHolderSlots)
        {
            if (weaponSlot.isLeftHandSlot)
            {
                leftHandSlot = weaponSlot;
            }
            else if(weaponSlot.isRightHandSlot)
            {
                rightHandSlot = weaponSlot;
            }
        }
    }

    public void LoadWeaponOnSlot(WeaponItem weaponItem, bool isLeft)
    {
        if (isLeft)
        {
            leftHandSlot.LoadWeaponModel(weaponItem);
            LoadLeftWeaponDamageCollider();
            quickSlotsUI.UpdateWeaponQuickSlotsUI(true, weaponItem);
            
            if (weaponItem != null)
            {
                anim.CrossFade(weaponItem.left_Hand_Idle, 0.2f);
            }
            else
            {
                anim.CrossFade("Left Arm Empty", 0.2f);
            }

        }
        else
        {
            rightHandSlot.LoadWeaponModel(weaponItem);
            LoadRightWeaponDamageCollider();
            quickSlotsUI.UpdateWeaponQuickSlotsUI(false, weaponItem);

            if (weaponItem != null)
            {
                anim.CrossFade(weaponItem.right_Hand_Idle, 0.2f);
            }
            else
            {
                anim.CrossFade("Right Arm Empty", 0.2f);
            }
        }
    }

    public void LoadFoodSlot(WeaponItem weapon)
    {
        quickSlotsUI.UpdateFoodIcon(weapon);
    }


    #region HandleWeaponsDamageCollider
    void LoadLeftWeaponDamageCollider()
    {
        leftHandDamageCollider = leftHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
    }

    void LoadRightWeaponDamageCollider()
    {
        rightHandDamageCollider = rightHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
    }

    public void OpenRightDamageCollider()
    {
        //Debug.Log("Right O");
        rightHandDamageCollider.EnableDamageCollider();
    }
    public void OpenLeftDamageCollider()
    {
        //Debug.Log("Left O");
        leftHandDamageCollider.EnableDamageCollider();
    }

    public void CloseRightDamageCollider()
    {
        //Debug.Log("Right C");
        rightHandDamageCollider.DisableDamageCollider();
    }

    public void CloseLeftDamageCollider()
    {
        //Debug.Log("Left C");
        leftHandDamageCollider.DisableDamageCollider();
    }
    #endregion

    #region Stamina Drain
    public void DrainStaminaLightAttack()
    {
        playerStats.TakeStaminaDamage(Mathf.RoundToInt(attackingWeapon.baseStamina * attackingWeapon.lightAttackMultiplier));
    }

    public void DrainStaminaHeavyAttack()
    {
        playerStats.TakeStaminaDamage(Mathf.RoundToInt(attackingWeapon.baseStamina * attackingWeapon.heavyAttackMultiplier));
    }
#endregion

}
