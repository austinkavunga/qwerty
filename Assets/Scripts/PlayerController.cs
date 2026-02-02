using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;

    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator animator;

    [SerializeField] public static bool isRunning;
    [SerializeField] public static bool sprintPressed;
    

    private void Awake()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        sprintPressed = false;
        isRunning = false;


        moveSpeed = 3f;

        playerControls.Movement.Sprint.performed += ctx => ahhh();
        playerControls.Movement.Sprint.canceled += ctx => nooo();

    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Update()
    {
        PlayerInput();



        if (isRunning == true)
        {
            moveSpeed = 5f;
        }
        else if (isRunning == false)
        {
            moveSpeed = 3f;
        }

    }

    private void FixedUpdate()
    {
        Move();
    }

    private void PlayerInput()
    {
        animator.SetBool("isWalking", true);
        movement = playerControls.Movement.Move.ReadValue<Vector2>();
        animator.SetFloat("InputX", movement.x);
        animator.SetFloat("InputY", movement.y);
        if (movement == Vector2.zero)
        {
            animator.SetBool("isWalking", false);
        }
    }

    private void Move()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

    private void ahhh()
    {
        sprintPressed = true;
    }

    private void nooo()
    {
        sprintPressed = false;
    }

}

