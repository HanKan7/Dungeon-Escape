using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public PlayerInventory playerInventory;

    public GameObject selectWindow;

    [Header("Weapons Inventory")]
    public GameObject weaponInventorySlotPrefab;
    WeaponInventorySlot[] weaponsInvSlots;
    public Transform weaponInvSlotsParent;

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
}
