using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public PlayerInventory playerInventory;

    [Header("UI Windows")]
    public GameObject hudWindow;
    public GameObject selectWindow;
    public GameObject weaponInventoryWindow;

    [Header("Weapons Inventory")]
    public GameObject weaponInventorySlotPrefab;
    WeaponInventorySlot[] weaponsInvSlots;
    public Transform weaponInvSlotsParent;


    private void Start()
    {
        weaponsInvSlots = weaponInvSlotsParent.GetComponentsInChildren<WeaponInventorySlot>();
    }
    public void UpdateUI()
    {
        #region weaponsInvSlots
        for(int i = 0; i < weaponsInvSlots.Length; i++)
        {
            if(i < playerInventory.weaponsInventory.Count)
            {
                if(weaponsInvSlots.Length < playerInventory.weaponsInventory.Count)
                {
                    Instantiate(weaponInventorySlotPrefab, weaponInvSlotsParent);
                    weaponsInvSlots = weaponInvSlotsParent.GetComponentsInChildren<WeaponInventorySlot>();
                }
                weaponsInvSlots[i].AddItem(playerInventory.weaponsInventory[i]);
                
            }
            else
            {
                weaponsInvSlots[i].ClearInventorySlot();
            }
        }
        #endregion
    }

    public void OpenSelectWindow()
    {
        selectWindow.SetActive(true);
    }

    public void CloseSelectWindow()
    {
        selectWindow.SetActive(false);
    }

    public void CloseAllInventoryWindows()
    {
        weaponInventoryWindow.SetActive(false);
    }
}
