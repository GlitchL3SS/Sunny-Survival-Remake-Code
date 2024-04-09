using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PM : MonoBehaviour
{
    // Movement variables
    public float speed;
    public float jumpForce;
    public bool jumpCooldown;
    // Ground check
    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;
    // Sprite
    public GameObject sprite;
    // Rigidbody reference
    private Rigidbody2D rb;
    // Sprite Renderer reference
    private SpriteRenderer spriteRenderer;
    // Animator reference
    private Animator animator;
    // Animator variables
    private float idleState;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = sprite.GetComponent<SpriteRenderer>();
        animator = sprite.GetComponent<Animator>();
    }

    void Update()
    {
        // Horizontal movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        // Ground check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        // Jump logic
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            animator.SetTrigger("Jump");
        }
        if (Input.GetKeyUp(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        // Checks if player is in the air
        if (!isGrounded)
            animator.SetBool("InAir", true);
        else animator.SetBool("InAir", false);
        // Flip sprite based on direction
        spriteRenderer.flipX = moveInput < 0;
        // Changes the idle state every second
        idleState = Mathf.PingPong(Time.time, 1.0f);
        // Update animation state
        animator.SetFloat("Idle", idleState);
    }
}