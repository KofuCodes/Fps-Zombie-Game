using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charactermovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float jumpForce;
    private Vector3 moveDir = Vector3.zero;
    private CharacterController controller;

    [SerializeField] private float gravity;
    [SerializeField] private float groundDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private bool isCharacterGrounded = false;
    private Vector3 velocity = Vector3.zero;

    private Animator anim;

    private void Start()
    {
        InitVariables();
        GetRef();
    }

    private void Update()
    {
        HandleIsGrounded();
        HandleJump();
        HandleGravity();

        HandleRunning();
        HandleMovement();
        HandleAnimation();
    }

    private void HandleMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        moveDir = new Vector3(moveX, 0, moveZ);
        moveDir = moveDir.normalized;
        moveDir = transform.TransformDirection(moveDir);

        controller.Move(moveDir * moveSpeed * Time.deltaTime);
    }

    private void HandleRunning()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = runSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = walkSpeed;
        }
    }

    private void HandleAnimation()
    {
        if(moveDir == Vector3.zero)
        {
            anim.SetFloat("Speed", 0f, 0.2f, Time.deltaTime);
        }
        else if(moveDir != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetFloat("Speed", 0.5f, 0.2f, Time.deltaTime);
        }
        else if (moveDir != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetFloat("Speed", 1f, 0.2f, Time.deltaTime);
        }
    }

    private void HandleIsGrounded()
    {
        isCharacterGrounded = Physics.CheckSphere(transform.position, groundDistance, groundMask);
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isCharacterGrounded) 
        {
            velocity.y += Mathf.Sqrt(jumpForce * -2 * gravity);
        }
    }

    private void HandleGravity()
    {
        if (isCharacterGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void GetRef()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    private void InitVariables()
    {
        moveSpeed = walkSpeed;
    }
}
