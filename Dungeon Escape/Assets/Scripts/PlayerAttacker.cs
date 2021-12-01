using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{

    AnimatorHandler animatorHandler;
    InputHandler inputHandler;
    PlayerInventory playerInventory;
    WeaponSlotManager weaponSlotManager;
    public string lastAttack;

    private void Awake()
    {
        animatorHandler = GetComponentInChildren<AnimatorHandler>();
        inputHandler = GetComponent<InputHandler>();
        playerInventory = GetComponent<PlayerInventory>();
        weaponSlotManager = GetComponentInChildren<WeaponSlotManager>();
    }

    public void HandleWeaponCombo(WeaponItem weapon)
    {
        if (inputHandler.comboFlag)
        {
            animatorHandler.anim.SetBool("canDoCombo", false);
            if (lastAttack == weapon.OH_Light_Attack_01)
            {
                animatorHandler.PlayTargetAnimation(weapon.OH_Heavy_Attack_01, true);
            }
        }
        
    }

    public void HandleLightAttack(WeaponItem weapon)
    {
        if (playerInventory.currentRightWeaponIndex == -1) return;
        weaponSlotManager.attackingWeapon = weapon;
        animatorHandler.PlayTargetAnimation(weapon.OH_Light_Attack_01, true);
        lastAttack = weapon.OH_Light_Attack_01;
    }

    public void HandleHeavyAttack(WeaponItem weapon)
    {
        if (playerInventory.currentRightWeaponIndex == -1) return;
        weaponSlotManager.attackingWeapon = weapon;
        animatorHandler.PlayTargetAnimation(weapon.OH_Heavy_Attack_01, true);
        lastAttack = weapon.OH_Heavy_Attack_01;
    }
}
