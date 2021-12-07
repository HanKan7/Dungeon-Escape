using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorHandler : MonoBehaviour
{
    public Animator anim;
    InputHandler inputHandler;
    PlayerLocomotion playerLocomotion;
     PlayerManager playerManager;
    int vertical, horizontal;
    public bool canRotate;

    private CapsuleCollider capsuleCollider;
    public AudioSource audioSource;
    public AudioSource audioSource2;

    public AudioClip swooshClip;
    private bool is_Idle = true;

    public void Initialize()
    {
        playerManager = GetComponentInParent<PlayerManager>();
        anim = GetComponent<Animator>();
        inputHandler = GetComponentInParent<InputHandler>();
        playerLocomotion = GetComponentInParent<PlayerLocomotion>();
        vertical = Animator.StringToHash("Vertical");
        horizontal = Animator.StringToHash("Horizontal");
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    public void UpdateAnimatorValues(float verticalMovement, float horizontalMovement, bool isSprinting)
    {
        #region Vertical
        float v = 0;
        if (verticalMovement > 0 && verticalMovement < 0.55f)
        {
            v = 0.5f;
        }
        else if(verticalMovement > 0.55f)
        {
            v = 1;
        }
        else if(verticalMovement < 0 && verticalMovement > -0.55f)
        {
            v = -0.5f;
        }
        else if(verticalMovement < -0.55f)
        {
            v = -1;
        }
        else
        {
            v = 0;
        }
        #endregion

        #region Horizontal
        float h = 0;
        if (horizontalMovement > 0 && horizontalMovement < 0.55f)
        {
            h = 0.5f;
        }
        else if (horizontalMovement > 0.55f)
        {
            h = 1;
        }
        else if (horizontalMovement < 0 && horizontalMovement > -0.55f)
        {
            h = -0.5f;
        }
        else if (horizontalMovement < -0.55f)
        {
            h = -1;
        }
        else
        {
            h = 0;
        }
        #endregion

        if (isSprinting)
        {
            v = 2;
            h = horizontalMovement;
        }

        anim.SetFloat(vertical, v, 0.1f, Time.deltaTime);
        anim.SetFloat(horizontal, h, 0.1f, Time.deltaTime);
    }

    public void PlayTargetAnimation(string targetAnim, bool isInteracting)
    {
        anim.applyRootMotion = isInteracting;
        anim.SetBool("isInteracting", isInteracting);
        anim.CrossFade(targetAnim, 0.2f);
    }

    public void CanRotate()
    {
        canRotate = true;
    }

    public void StopRotation()
    {
        canRotate = false;
    }

    private void OnAnimatorMove()
    {
        if(playerManager.isInteracting == false)
        {
            return;
        }

        float delta = Time.deltaTime;
        playerLocomotion.rigidBody.drag = 0;
        Vector3 deltaPosition = anim.deltaPosition;
        deltaPosition.y = 0;
    }

    public void EnableCombo()
    {
        anim.SetBool("canDoCombo", true);
    }

    public void DisableCombo()
    {
        anim.SetBool("canDoCombo", false);
    }
    public void CapColliderOn()
    {
        Debug.Log("CapColliderOn");
        capsuleCollider.height = 2.2f;
    }
    public void CapColliderOff()
    {
        Debug.Log("CapColliderOff");
        capsuleCollider.height = 1.5f;
    }
    public void PlayFootStep()
    {
        is_Idle = false;
    }
    public void DisableFootStep()
    {
        is_Idle = true;
    }
    public void PlaySlashSound()
    {
        if(audioSource)
        audioSource2.PlayOneShot(swooshClip);
    }
    private void Update()
    {
        if (!is_Idle && !audioSource.isPlaying)
            audioSource.Play();
        if (is_Idle && audioSource.isPlaying)
            audioSource.Stop();
    }
}
