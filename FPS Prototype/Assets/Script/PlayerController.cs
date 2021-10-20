using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Input KeyCodes")]
    [SerializeField]
    private KeyCode keyCodeRun = KeyCode.LeftShift; //�޸��� Ű

    [Header("Input KeyCodes")]
    [SerializeField]
    private KeyCode keyCodeJump = KeyCode.Space; //���� Ű

    [Header("Audio Clips")]
    [SerializeField]
    private AudioClip audioClipWalk; //�ȱ� ����
    [SerializeField]
    private AudioClip audioClipRun; //�޸��� ����


    private RotateToMouse rotateToMouse; //���콺 �̵����� ī�޶� ȸ��
    private MovementPlayerController movement;//Ű���� �Է����� �÷��̾� �̵�, ����
    private Status status;//�̵��ӵ����� �÷��̾� ����
    private PlayerAnimatorController animator; //�ִϸ��̼� ��� ����
    private AudioSource audioSource; //���� ��� ����
    private WeaponAssaultRifle weapon; //���⸦ �̿��� ���� ����

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        rotateToMouse = GetComponent<RotateToMouse>();
        movement = GetComponent<MovementPlayerController>();
        status = GetComponent<Status>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<PlayerAnimatorController>();
        weapon = GetComponentInChildren<WeaponAssaultRifle>();
    }

    private void Update()
    {
        UpdateRotate();
        UpdateJump();
        UpdateMove();
        UpdateWeaponAction();
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
        //���ڸ�
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

    private void UpdateWeaponAction()
    {
        if(Input.GetMouseButtonDown(0))
        {
            weapon.StartWeaponAction();
        }
        else if(Input.GetMouseButtonUp(0))
        {
            weapon.StopWeaponAction();
        }
    }

}
