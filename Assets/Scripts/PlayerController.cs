using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;

    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator animator;
    
    public static bool isRunning;

    private void Awake()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Update()
    {
        PlayerInput();
        if (isRunning)
        {
            moveSpeed = 5f;
        }
        else
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
}
