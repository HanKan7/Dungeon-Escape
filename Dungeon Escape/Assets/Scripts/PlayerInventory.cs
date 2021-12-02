using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    WeaponSlotManager weaponSlotManager;
    public WeaponItem rightWeapon, leftWeapon, unarmedWeapon, food;
    public List<WeaponItem> weaponsInRightHandSlots;
    public List<WeaponItem> weaponsInLeftHandSlots;
    public List<WeaponItem> items;

    public int currentRightWeaponIndex = -1;
    public int currentLeftWeaponIndex = -1;
    public int currentItemIndex = -1;
    public int itemCount = 0;

    public List<WeaponItem> weaponsInventory;
    public List<WeaponItem> itemInventory;

    private void Awake()
    {
        weaponSlotManager = GetComponentInChildren<WeaponSlotManager>();
        
    }

    private void Start()
    {
        //rightWeapon = weaponsInRightHandSlots[currentRightWeaponIndex];
        //leftWeapon = weaponsInLeftHandSlots[currentLeftWeaponIndex];
        //weaponSlotManager.LoadWeaponOnSlot(rightWeapon, false);
        //weaponSlotManager.LoadWeaponOnSlot(leftWeapon, true);
        rightWeapon = unarmedWeapon;
        leftWeapon = unarmedWeapon;

    }

    public void AddWeapon(WeaponItem weapon)
    {
        weaponsInRightHandSlots.Add(weapon);
        weaponsInLeftHandSlots.Add(weapon);
    }

    public void ChangeItemSlot()
    {
        if(itemCount > 0)
        {
            
            currentItemIndex = currentItemIndex + 1;
            if (currentItemIndex == 0 && items[0] != null)
            {
                Debug.Log("Here");
                food = items[currentItemIndex];
                weaponSlotManager.LoadFoodSlot(items[currentItemIndex]);

            }
            else if (currentItemIndex == 0 && items[0] == null)
            {
                currentItemIndex++;
            }
            else if (itemCount > 1)
            {
                if (currentItemIndex == 1 && items[1] != null)
                {
                    food = items[currentItemIndex];
                    weaponSlotManager.LoadFoodSlot(items[currentItemIndex]);
                }
                else
                {
                    currentItemIndex++;
                }
            }



            if (currentItemIndex > itemCount - 1)
            {
                currentItemIndex = -1;
                food = unarmedWeapon;
                weaponSlotManager.LoadFoodSlot(unarmedWeapon);
            }
        }
    
    }

    public void ChangeRightWeapon()
    {
        if (weaponsInventory.Count > 0)
        {
            currentRightWeaponIndex = currentRightWeaponIndex + 1;
            if (currentRightWeaponIndex == 0 && weaponsInRightHandSlots[0] != null)
            {
                rightWeapon = weaponsInRightHandSlots[currentRightWeaponIndex];
                weaponSlotManager.LoadWeaponOnSlot(weaponsInRightHandSlots[currentRightWeaponIndex], false);

            }
            else if (currentRightWeaponIndex == 0 && weaponsInRightHandSlots[0] == null)
            {
                currentRightWeaponIndex++;
            }
            else if(weaponsInventory.Count > 1)
            {
                if (currentRightWeaponIndex == 1 && weaponsInRightHandSlots[1] != null)
                {
                    rightWeapon = weaponsInRightHandSlots[currentRightWeaponIndex];
                    weaponSlotManager.LoadWeaponOnSlot(weaponsInRightHandSlots[currentRightWeaponIndex], false);
                }
                else
                {
                    currentRightWeaponIndex++;
                }
            }
            
            

            if (currentRightWeaponIndex > weaponsInRightHandSlots.Count - 1)
            {
                currentRightWeaponIndex = -1;
                rightWeapon = unarmedWeapon;
                weaponSlotManager.LoadWeaponOnSlot(unarmedWeapon, false);
            }
        }
    }

    public void ChangeLeftWeapon()
    {
        if (weaponsInventory.Count > 0)
        {

            currentLeftWeaponIndex = currentLeftWeaponIndex + 1;
            if (currentLeftWeaponIndex == 0 && weaponsInLeftHandSlots[0] != null)
            {
                leftWeapon = weaponsInLeftHandSlots[currentLeftWeaponIndex];
                weaponSlotManager.LoadWeaponOnSlot(weaponsInLeftHandSlots[currentLeftWeaponIndex], true);

            }
            else if (currentLeftWeaponIndex == 0 && weaponsInLeftHandSlots[0] == null)
            {
                currentLeftWeaponIndex++;
            }
            else if (weaponsInventory.Count > 1)
            {
                if (currentLeftWeaponIndex == 1 && weaponsInLeftHandSlots[1] != null)
                {
                    leftWeapon = weaponsInLeftHandSlots[currentLeftWeaponIndex];
                    weaponSlotManager.LoadWeaponOnSlot(weaponsInLeftHandSlots[currentLeftWeaponIndex], true);
                }
                else
                {
                    currentLeftWeaponIndex++;
                }

            }

            if (currentLeftWeaponIndex > weaponsInLeftHandSlots.Count - 1)
            {
                currentLeftWeaponIndex = -1;
                leftWeapon = unarmedWeapon;
                weaponSlotManager.LoadWeaponOnSlot(unarmedWeapon, true);
            }
        }
    }
}
