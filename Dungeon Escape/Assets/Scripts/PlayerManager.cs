using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    InputHandler inputHandler;
    Animator anim;

    [Header("Player Flags")]
    public bool isInteracting;
    public bool isSprinting;
    public bool isGrounded;
    public bool isInAir;
    public bool canDoCombo;


    CameraHandler cameraHandler;
    PlayerLocomotion playerLocomotion;

    private void Awake()
    {
        cameraHandler = FindObjectOfType<CameraHandler>();
    }

    private void Start()
    {
        inputHandler = GetComponent<InputHandler>();
        anim = GetComponentInChildren<Animator>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    private void FixedUpdate()
    {
        float delta = Time.fixedDeltaTime;
        if (cameraHandler != null)
        {
            cameraHandler.FollowTarget(delta);
            cameraHandler.HandleCameraRotation(delta, inputHandler.mouseX, inputHandler.mouseY);
        }
    }

    private void Update()
    {
        isInteracting = anim.GetBool("isInteracting");
        canDoCombo = anim.GetBool("canDoCombo");


        float delta = Time.deltaTime;

        inputHandler.TickInput(delta);
        playerLocomotion.HandleMovement(delta);
        playerLocomotion.HandleRollingAndSpriting(delta);
        playerLocomotion.HandleFalling(delta, playerLocomotion.moveDirection);
        
    }

    private void LateUpdate()
    {

        inputHandler.rollFlag = false;
        inputHandler.sprintFlag = false;
        inputHandler.rb_Input = false;
        inputHandler.rt_Input = false;

        inputHandler.up_Input = false;
        inputHandler.down_Input = false;
        inputHandler.left_Input = false;
        inputHandler.right_Input = false;
        
        if (isInAir)
        {
            playerLocomotion.inAirTimer = playerLocomotion.inAirTimer + Time.deltaTime;
        }
    }
}
