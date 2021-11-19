using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public float horizontal, vertical, moveAmount, mouseX, mouseY;

    PlayerControls inputActions;
    Vector2 moveInput, cameraInput;

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
    }

    void MoveInput(float delta)
    {
        horizontal = moveInput.x;
        vertical = moveInput.y;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));
        mouseX = cameraInput.x;
        mouseY = cameraInput.y;
    }
}
