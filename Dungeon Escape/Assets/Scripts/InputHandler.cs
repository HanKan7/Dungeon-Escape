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


    public bool rollFlag;
    public bool sprintFlag;
    public bool comboFlag;


    public float rollInputTimer;

    PlayerControls inputActions;
    PlayerAttacker playerAttacker;
    PlayerInventory playerInventory;
    PlayerManager playerManager;

    Vector2 moveInput, cameraInput;

    private void Awake()
    {
        playerAttacker = GetComponent<PlayerAttacker>();
        playerInventory = GetComponent<PlayerInventory>();
        playerManager = GetComponent<PlayerManager>();
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
        HandleInteractableInput();
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

    void HandleInteractableInput()
    {
        inputActions.PlayerActions.F.performed += i => f_input = true;
    }
}
