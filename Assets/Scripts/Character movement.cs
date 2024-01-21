using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Charactermovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float maxStamina = 100f; // The maximum stamina
    [SerializeField] private float stamina = 100f; // The current stamina
    [SerializeField] private float staminaConsumptionRate = 10f; // Stamina consumed per second while running
    [SerializeField] private float staminaRegenerationRate = 5f;
    [SerializeField] private float jumpForce;
    private Vector3 moveDir = Vector3.zero;
    private CharacterController controller;

    [SerializeField] private float gravity;
    [SerializeField] private float groundDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private bool isCharacterGrounded = false;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private Slider staminaBar;

    private Animator anim;
    private PlayerStats stats;

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
        RegenerateStamina();
        UpdateStaminaBar();
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

        if (!stats.IsDead())
        {
            controller.Move(moveDir * moveSpeed * Time.deltaTime);
        }
    }

    private void HandleRunning()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && stamina > 0)
        {
            moveSpeed = runSpeed;
        }
        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0)
        {
            stamina -= staminaConsumptionRate * Time.deltaTime;
            stamina = Mathf.Max(stamina, 0); // Ensure stamina doesn't go below 0
            if (stamina <= 0)
            {
                moveSpeed = walkSpeed; // Force the player to walk if stamina is depleted
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = walkSpeed;
        }
    }

    private void RegenerateStamina()
    {
        if (moveSpeed == walkSpeed && stamina < maxStamina)
        {
            stamina += staminaRegenerationRate * Time.deltaTime;
            stamina = Mathf.Min(stamina, maxStamina); // Prevent stamina from exceeding maxStamina
        }
    }

    private void UpdateStaminaBar()
    {
        // Update the stamina bar's value to reflect the current stamina
        staminaBar.value = stamina;
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
        stats = GetComponent<PlayerStats>();
        staminaBar.maxValue = maxStamina;
        staminaBar.value = stamina;
    }

    private void InitVariables()
    {
        moveSpeed = walkSpeed;
    }
}
