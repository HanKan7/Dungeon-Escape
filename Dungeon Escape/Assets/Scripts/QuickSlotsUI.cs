using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickSlotsUI : MonoBehaviour
{
    public Image leftWeaponIcon, rightWeaponIcon, healthIcon;

    public void UpdateWeaponQuickSlotsUI(bool isLeft, WeaponItem weapon)
    {
        if(isLeft == false)
        {
            if (weapon.itemIcon != null)
            {
                rightWeaponIcon.sprite = weapon.itemIcon;
                rightWeaponIcon.enabled = true;
            }
            else
            {
                rightWeaponIcon.sprite = null;
                rightWeaponIcon.enabled = false; 
            }
            
        }
        else
        {
            if(weapon.itemIcon != null)
            {
                leftWeaponIcon.sprite = weapon.itemIcon;
                leftWeaponIcon.enabled = true;
            }
            else
            {
                leftWeaponIcon.sprite = null;
                leftWeaponIcon.enabled = false;
            }
        }
    }

    public void UpdateFoodIcon(WeaponItem weapon)
    {
        if (weapon.itemIcon != null)
        {
            healthIcon.sprite = weapon.itemIcon;
            healthIcon.enabled = true;
        }
        else
        {
            healthIcon.sprite = null;
            healthIcon.enabled = false;
        }
    }
}
