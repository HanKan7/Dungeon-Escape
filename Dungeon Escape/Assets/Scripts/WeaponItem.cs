using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Item/Weapon Item")] 
public class WeaponItem : Item
{
    public GameObject modelPrefab;
    public bool isUnarmed;

    [Header("Idle Animation")]
    public string right_Hand_Idle;
    public string left_Hand_Idle;


    [Header("One Handed Attack Animation")]
    public string OH_Light_Attack_01;
    public string OH_Heavy_Attack_01;

}
