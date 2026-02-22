using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, PlayerControls.IMovementActions
{
    [SerializeField] private float moveSpeed = 1f;

    private PlayerControls playerControls;
    private Vector2 movement;
    private Vector2 lastMovement = new Vector2(0f, -1f);
    private Rigidbody2D rb;
    private Animator animator;

    private void Awake()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        // Register callbacks and enable the action map
        playerControls.Movement.SetCallbacks(this);
        playerControls.Enable();
    }

    private void OnDisable()
    {
        // Unregister callbacks and disable the action map
        playerControls.Movement.SetCallbacks(null);
        playerControls.Disable();
    }
    private void FixedUpdate()
    {
        Move();
    }

    // Input callback from the generated PlayerControls class
    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    private void Move()
    {
        // If we have input, we're walking and we update the facing direction
        if (movement.sqrMagnitude > 0.0001f)
        {
            animator.SetBool("isWalking", true);
            animator.SetFloat("InputX", movement.x);
            animator.SetFloat("InputY", movement.y);
            lastMovement = movement;

            // normalize so diagonal movement isn't faster
            Vector2 moveDir = movement.normalized;
            rb.MovePosition(rb.position + moveDir * (moveSpeed * Time.fixedDeltaTime));
        }
        else
        {
            // No input: switch to idle but keep the last facing direction so idle looks correct
            animator.SetBool("isWalking", false);
            animator.SetFloat("InputX", lastMovement.x);
            animator.SetFloat("InputY", lastMovement.y);
        }
    }
}
