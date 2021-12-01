using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    InputHandler inputHandler;
    PlayerStats playerStats;
    Animator anim;
    public LayerMask interactableLayer;

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
        playerStats = GetComponent<PlayerStats>();
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
        if (playerStats.currentHealth <= 0) return;
        //if (isInteracting) return;
        CheckForInteractable();
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
        inputHandler.f_input = false;
        
        if (isInAir)
        {
            playerLocomotion.inAirTimer = playerLocomotion.inAirTimer + Time.deltaTime;
        }
    }

    public void CheckForInteractable()
    {
        RaycastHit hit;
        
        if(Physics.SphereCast(transform.position, 0.3f, transform.forward, out hit, 1f, cameraHandler.ignoreLayers))
        {

            if (hit.collider.tag == "Interactable")
            {
                Debug.Log("Int");
                Interactable interactableObject = hit.collider.GetComponent<Interactable>();

                if(interactableObject != null)
                {
                    string interactableText = interactableObject.interactableText; //Set the UI Text to interactable obj text // Enable UI pop up

                    if (inputHandler.f_input)
                    {
                        hit.collider.GetComponent<Interactable>().Interact(this);
                    }
                }
            }
        }
        Debug.DrawRay(transform.position + new Vector3(0,1,0), transform.forward, Color.red);
        if(Physics.Raycast(transform.position + new Vector3(0, 1, 0), transform.forward, out hit))
        {
            if (hit.collider.tag == "Interactable")
            {
                Interactable interactableObject = hit.collider.GetComponent<Interactable>();

                if (interactableObject != null)
                {
                    string interactableText = interactableObject.interactableText; //Set the UI Text to interactable obj text // Enable UI pop up

                    if (inputHandler.f_input)
                    {
                        hit.collider.GetComponent<Interactable>().Interact(this);
                    }
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 1f);
    }
}
