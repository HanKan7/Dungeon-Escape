using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public float horizontal, vertical, moveAmount, mouseX, mouseY;

    public bool b_Input;
    public bool rb_Input;
    public bool rt_Input;
    public bool up_Input;
    public bool down_Input;
    public bool left_Input;
    public bool right_Input;
    public bool f_input;
    public bool jump_input;
    public bool inv_Input;


    public bool rollFlag;
    public bool sprintFlag;
    public bool comboFlag;
    public bool inventoryFlag;


    public float rollInputTimer;

    PlayerControls inputActions;
    PlayerAttacker playerAttacker;
    PlayerInventory playerInventory;
    PlayerManager playerManager;
    PlayerStats playerStats;
    UIManager uIManager;
    WeaponSlotManager weaponSlotManager;

    Vector2 moveInput, cameraInput;

    private void Awake()
    {
        playerAttacker = GetComponent<PlayerAttacker>();
        playerInventory = GetComponent<PlayerInventory>();
        playerManager = GetComponent<PlayerManager>();
        uIManager = FindObjectOfType<UIManager>();
        playerStats = GetComponent<PlayerStats>();
        weaponSlotManager = FindObjectOfType<WeaponSlotManager>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnEnable()
    {
        if(inputActions == null)
        {
            inputActions = new PlayerControls();
            inputActions.PlayerMovement.Movement.performed += inputActions => moveInput = inputActions.ReadValue<Vector2>();
            inputActions.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
        }
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    public void TickInput(float delta)
    {
        MoveInput(delta);
        HandleRollInput(delta);
        HandleAttackInput(delta);
        HandleQuickSlotInput();
        HandleFoodInput();
        HandleInteractableInput();
        HandleJumpInput();
        HandleInventoryInput();
        HandleEatInput();
    }

    void MoveInput(float delta)
    {
        horizontal = moveInput.x;
        vertical = moveInput.y;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));
        mouseX = cameraInput.x;
        mouseY = cameraInput.y;
    }

    void HandleRollInput(float delta)
    {
        b_Input = inputActions.PlayerActions.Roll.phase == UnityEngine.InputSystem.InputActionPhase.Started;
        if (b_Input)
        {
            rollInputTimer += delta;
            sprintFlag = true;
        }
        else
        {
            if(rollInputTimer > 0 && rollInputTimer < 0.5f)
            {
                sprintFlag = false;
                rollFlag = true;
            }
            rollInputTimer = 0;
        }
    }

    void HandleAttackInput(float delta)
    {
        inputActions.PlayerActions.RB.performed += inputActions => rb_Input = true;
        inputActions.PlayerActions.RT.performed += inputActions => rt_Input = true;

        if (rb_Input)
        {
            if (playerManager.canDoCombo)
            {
                comboFlag = true;
                playerAttacker.HandleWeaponCombo(playerInventory.rightWeapon);
                comboFlag = false;
            }
            else
            {
                if (playerManager.isInteracting) return;
                if (playerManager.canDoCombo) return;
                playerAttacker.HandleLightAttack(playerInventory.rightWeapon);
            }
            //playerAttacker.HandleLightAttack(playerInventory.rightWeapon);
        }
        if (rt_Input)
        {
            playerAttacker.HandleHeavyAttack(playerInventory.rightWeapon);
        }
    }

    void HandleQuickSlotInput()
    {
        inputActions.PlayerInventory.RightArrow.performed += i => right_Input = true;
        inputActions.PlayerInventory.LeftArrow.performed += i => left_Input = true;
        if (right_Input)
        {
            playerInventory.ChangeRightWeapon();
        }
        else if (left_Input)
        {
            playerInventory.ChangeLeftWeapon();
        }
    }

    void HandleFoodInput()
    {
        inputActions.PlayerInventory.UpArrow.performed += i => up_Input = true;
        inputActions.PlayerInventory.DownArrow.performed += i => down_Input = true;

        if (up_Input)
        {
            playerInventory.ChangeItemSlot();
        }
        else if (down_Input)
        {
            playerInventory.ChangeItemSlot();
        }
    }
    void HandleEatInput()
    {
        inputActions.PlayerActions.Jump.performed += i => jump_input = true;

        if (jump_input)
        {
            if(playerInventory.itemInventory.Count > 0 && playerInventory.currentItemIndex != -1)
            {

                playerStats.GainHealth(playerInventory.items[playerInventory.currentItemIndex].baseStamina);
                playerInventory.itemInventory.RemoveAt(playerInventory.currentItemIndex);
                playerInventory.itemCount--;
                playerInventory.currentItemIndex = -1;
                playerInventory.food = playerInventory.unarmedWeapon;
                weaponSlotManager.LoadFoodSlot(playerInventory.unarmedWeapon);
            }
        }
    }

    void HandleInteractableInput()
    {
        inputActions.PlayerActions.F.performed += i => f_input = true;
    }

    void HandleJumpInput()
    {
        inputActions.PlayerActions.Jump.performed += i => jump_input = true;
    }

    void HandleInventoryInput()
    {
        inputActions.PlayerActions.Inventory.performed += i => inv_Input = true;
        
        if (inv_Input)
        {

            inventoryFlag = !inventoryFlag;
            if(inventoryFlag)
            {
                uIManager.OpenSelectWindow();
                uIManager.UpdateUI();
                uIManager.hudWindow.SetActive(false);
            }
            else
            {
                uIManager.CloseSelectWindow();
                uIManager.CloseAllInventoryWindows();
                uIManager.hudWindow.SetActive(true);
            }
        }
    }
}
