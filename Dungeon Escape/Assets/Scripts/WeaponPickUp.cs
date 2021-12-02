using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponPickUp : Interactable
{
    public WeaponItem weapon;
    public override void Interact(PlayerManager playerManager)
    {
        base.Interact(playerManager);

        PickUpItem(playerManager);

    }

    void PickUpItem(PlayerManager playerManager)
    {
        PlayerInventory playerInventory;
        PlayerLocomotion playerLocomotion;
        AnimatorHandler animatorHandler;

        playerInventory = playerManager.GetComponent<PlayerInventory>();
        playerLocomotion = playerManager.GetComponent<PlayerLocomotion>();
        animatorHandler = playerManager.GetComponentInChildren<AnimatorHandler>();


        playerLocomotion.rigidBody.velocity = Vector3.zero;     //Stops the player from moving while picking up item
        animatorHandler.PlayTargetAnimation("Picking", true);
        if(interactableText == "Sword" || interactableText == "Gold Sword" || interactableText == "Key")
        {
            playerInventory.weaponsInventory.Add(weapon);
        }
        else if(interactableText == "Fish" || interactableText == "Ham")
        {
            playerInventory.itemInventory.Add(weapon);
            playerInventory.itemCount++;
        }
        playerManager.itemInteractableGameObject.GetComponentInChildren<TMP_Text>().text = "Last Picked Item: " + weapon.itemName;
        playerManager.itemInteractableGameObject.SetActive(true);
        Destroy(gameObject);
    }
}
