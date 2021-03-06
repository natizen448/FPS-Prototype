using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class MovementPlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;        //이동속도
    private Vector3 moveForce;//이동 힘 (x, z와 y축을 별도로 계산해 실제 이동에 적용)

    private CharacterController characterController;

    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float gravity;

    
    
    public float MoveSpeed
    {
        set => moveSpeed = Mathf.Max(0, value);
        get => moveSpeed;
    }
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        //1초당 moveForce 속력으로 이동
        characterController.Move(moveForce * Time.deltaTime);

        if(!characterController.isGrounded)
        {
            moveForce.y += gravity * Time.deltaTime;
        }    


    }

    public void MoveTo(Vector3 direction)
    {
        //이동 방향 = 캐릭터의 회전 값 * 방향 값
        direction = transform.rotation * new Vector3(direction.x, 0, direction.z);

        //이동 힘 = 이동방향 * 속도
        moveForce = new Vector3(direction.x * moveSpeed, moveForce.y, direction.z * moveSpeed);
    }

    public void Jump()
    {
        if(characterController.isGrounded)
        {
            moveForce.y = jumpForce;
        }
    }
}
