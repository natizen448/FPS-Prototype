using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Input KeyCodes")]
    [SerializeField]
    private KeyCode keyCodeRun = KeyCode.LeftShift;

    [Header("Input KeyCodes")]
    [SerializeField]
    private KeyCode keyCodeJump = KeyCode.Space;

    [Header("Audio Clips")]
    [SerializeField]
    private AudioClip audioClipWalk;
    [SerializeField]
    private AudioClip audioClipRun;


    private RotateToMouse rotateToMouse;
    private MovementPlayerController movement;
    private Status status;
    private PlayerAnimatorController animator;
    private AudioSource audioSource;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        rotateToMouse = GetComponent<RotateToMouse>();
        movement = GetComponent<MovementPlayerController>();
        status = GetComponent<Status>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<PlayerAnimatorController>();
    }

    private void Update()
    {
        UpdateRotate();
        UpdateMove();
    }

    private void UpdateMove()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if(x != 0 || z != 0)
        {
            bool isRun = false;

            if (z > 0)
                isRun = Input.GetKey(keyCodeRun);

            movement.MoveSpeed = isRun == true ? status.RunSpeed : status.WalkSpeed;
            animator.MoveSpeed = isRun == true ? 1 : 0.5f;
            audioSource.clip = isRun == true ? audioClipRun : audioClipWalk;

            if (!audioSource.isPlaying)
            {
                audioSource.loop = true;
                audioSource.Play();
            }
        }
        //Á¦ÀÚ¸®
        else
        {
            movement.MoveSpeed = 0;
            animator.MoveSpeed = 0;

            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }



        movement.MoveTo(new Vector3(x, 0, z));
    }

    private void UpdateRotate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rotateToMouse.UpdateRotate(mouseX, mouseY);
    }

    private void UpdateJump()
    {
        if(Input.GetKeyDown(keyCodeJump))
        {
            movement.Jump();
        }
    }
}
