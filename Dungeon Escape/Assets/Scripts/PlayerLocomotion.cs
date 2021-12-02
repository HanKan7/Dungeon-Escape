using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    Transform cameraObject;
    InputHandler inputHandler;
    PlayerManager playerManager;

    public Vector3 moveDirection;

    [HideInInspector]
    public Transform myTransform;
    [HideInInspector]
    public AnimatorHandler animatorHandler;
    public CapsuleCollider capsuleCollider;


    public new Rigidbody rigidBody;
    public GameObject normalCamera;

    [Header("Movement Stats")]  
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float rotationSpeed = 10f;
    [SerializeField] float sprintSpeed = 7f;
    [SerializeField] float walkSpeed = 1f;
    [SerializeField] float fallingSpeed = 45f;
    [SerializeField] float jumpSpeed = 15f;


    [Header("Ground and Air Detection Stats")]
    float groundDetectionRayStartPoint = 0.5f;
    [SerializeField] float minimumDistanceNeededToBeginFall = 1f;
    [SerializeField] float groundDirectionRayDistance = 0.2f;
    LayerMask ignoreGroundCheck;
    public float inAirTimer;


    private void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        rigidBody = GetComponent<Rigidbody>();
        inputHandler = GetComponent<InputHandler>();
        cameraObject = Camera.main.transform;
        animatorHandler = GetComponentInChildren<AnimatorHandler>();
        capsuleCollider = GetComponentInChildren<CapsuleCollider>();
        myTransform = transform;
        animatorHandler.Initialize();
        playerManager.isGrounded = true;
        ignoreGroundCheck = ~(1 << 8 | 1 << 11);
    }


    #region Movement
    Vector3 normalVector;
    Vector3 targetPosition;

    void HandleRotation(float delta)
    {
        Vector3 targetDir = Vector3.zero;
        float moveOverride = inputHandler.moveAmount;
        targetDir = cameraObject.forward * inputHandler.vertical;
        targetDir += cameraObject.right * inputHandler.horizontal;

        targetDir.Normalize();
        targetDir.y = 0;

        if(targetDir == Vector3.zero)
        {
            targetDir = myTransform.forward;
        }

        float rs = rotationSpeed;

        Quaternion tr = Quaternion.LookRotation(targetDir);
        Quaternion targetRotation = Quaternion.Slerp(myTransform.rotation, tr, rs * delta);
        myTransform.rotation = targetRotation;
    }

    public void HandleMovement(float delta)
    {
        if (inputHandler.rollFlag) return;
        if (playerManager.isInteracting) return;
        moveDirection = cameraObject.forward * inputHandler.vertical;
        moveDirection += cameraObject.right * inputHandler.horizontal;
        moveDirection.Normalize();
        moveDirection.y = 0;

        float speed = movementSpeed;
        if (inputHandler.sprintFlag && inputHandler.moveAmount > 0.5f)
        {
            speed = sprintSpeed;
            playerManager.isSprinting = true;
            moveDirection *= speed;
        }
        else
        {
            if(inputHandler.moveAmount < 0.5f)
            {
                moveDirection *= walkSpeed;
                playerManager.isSprinting = false;
                
            }
            else
            {

                moveDirection *= speed;
                playerManager.isSprinting = false;
            }
        }

        Vector3 projectedVelocity = Vector3.ProjectOnPlane(moveDirection, normalVector);
        rigidBody.velocity = projectedVelocity;

        animatorHandler.UpdateAnimatorValues(inputHandler.moveAmount, 0, playerManager .isSprinting);

        if (animatorHandler.canRotate)
        {
            HandleRotation(delta);
        }
    }

    public void HandleRollingAndSpriting(float delta)
    {
        if (animatorHandler.anim.GetBool("isInteracting"))
        {
            return;
        }

        if (inputHandler.rollFlag)
        {
            moveDirection = cameraObject.forward * inputHandler.vertical;
            moveDirection += cameraObject.right * inputHandler.horizontal;

            if(inputHandler.moveAmount > 0)
            {
                animatorHandler.PlayTargetAnimation("Roll", true);
                moveDirection.y = 0;
                Quaternion rollRotation = Quaternion.LookRotation(moveDirection);
                myTransform.rotation = rollRotation;
            }
            else
            {
                animatorHandler.PlayTargetAnimation("StepBack", true);
            }
        }
    }

    public void HandleFalling(float delta, Vector3 moveDirection)
    {
        capsuleCollider.center -= new Vector3(0, 1f, 0);
        playerManager.isGrounded = false;
        RaycastHit hit;
        Vector3 origin = myTransform.position;
        origin.y += groundDetectionRayStartPoint;
        if (Physics.Raycast(origin, myTransform.forward, out hit, 0.4f))
        {
            moveDirection = Vector3.zero;
        }


        if (playerManager.isInAir)
        {
            rigidBody.AddForce(-Vector3.up * fallingSpeed);
            rigidBody.AddForce(moveDirection * fallingSpeed / 10f);
        }

        Vector3 dir = moveDirection;
        dir.Normalize();
        origin = origin + dir * groundDetectionRayStartPoint;

        targetPosition = myTransform.position;

        Debug.DrawRay(origin, -Vector3.up * minimumDistanceNeededToBeginFall, Color.red, 0.1f, false);

        if (Physics.Raycast(origin, -Vector3.up, out hit, minimumDistanceNeededToBeginFall, ignoreGroundCheck))
        {
            normalVector = hit.normal;
            Vector3 tp = hit.point;
            playerManager.isGrounded = true;
            targetPosition.y = tp.y;

            if (playerManager.isInAir)
            {
                if (inAirTimer > 0.5f)
                {
                    Debug.Log("You were in the air for " + inAirTimer);
                    animatorHandler.PlayTargetAnimation("Land", true);
                    inAirTimer = 0;
                }
                else
                {
                    animatorHandler.PlayTargetAnimation("Empty", false);
                    inAirTimer = 0;
                }
                playerManager.isInAir = false;
            }
        }
        //Fall
        else
        {
            if (playerManager.isGrounded)
            {
                playerManager.isGrounded = false;
            }

            if (playerManager.isInAir == false)
            {
                if (playerManager.isInteracting == false)
                {
                    animatorHandler.PlayTargetAnimation("Fall", true);
                }

                Vector3 vel = rigidBody.velocity;
                vel.Normalize();
                rigidBody.velocity = vel * (movementSpeed / 2);
                playerManager.isInAir = true;

            }
        }

        if (playerManager.isGrounded)
        {
            if (playerManager.isInteracting || inputHandler.moveAmount > 0)
            {
                myTransform.position = Vector3.Lerp(myTransform.position, targetPosition, Time.deltaTime);
            }
            else
            {
                myTransform.position = targetPosition;
            }
        }

        if (playerManager.isInteracting || inputHandler.moveAmount > 0)
        {
            myTransform.position = Vector3.Lerp(myTransform.position, targetPosition, Time.deltaTime / 0.1f);
        }
        else
        {
            myTransform.position = targetPosition;
        }
    }

    public void HandleJumping()
    {
        if (playerManager.isInteracting) return;
        if (inputHandler.jump_input)
        {
            //if(inputHandler.moveAmount > 0)
            {
                moveDirection = cameraObject.forward * inputHandler.vertical;
                moveDirection += cameraObject.right * inputHandler.horizontal;
                animatorHandler.PlayTargetAnimation("Jump", true);
                moveDirection.y = 0;
                Quaternion jumpRotation = Quaternion.LookRotation(moveDirection);
                myTransform.rotation = jumpRotation;


                //moveDirection.Normalize();
                //moveDirection *= jumpSpeed;
                GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpSpeed * 100, 0) * Time.deltaTime);
                //capsuleCollider.center = new Vector3(0, 2f, 0);
                //transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(0, 2f, 0), 0.07f);
            }
        }
    }


    #endregion
}
