using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public float horizontal, vertical, moveAmount, mouseX, mouseY;
    public bool b_Input, rollFlag, sprintFlag;
    public bool isInteracting;
    public float rollInputTimer;

    PlayerControls inputActions;
    CameraHandler cameraHandler;


    Vector2 moveInput, cameraInput;

    private void Awake()
    {
        cameraHandler = CameraHandler.singleton;
    }

    private void FixedUpdate()
    {
        float delta = Time.fixedDeltaTime;
        if(cameraHandler != null)
        {
            cameraHandler.FollowTarget(delta);
            cameraHandler.HandleCameraRotation(delta, mouseX, mouseY);
        }
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
}
