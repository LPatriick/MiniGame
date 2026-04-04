using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private Animator anim;
    bool isGrounded;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            rb.linearVelocity = new Vector2(moveSpeed, jumpForce);
        }
        anim.SetBool("isJump", !isGrounded);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        isGrounded = true;
    }
    void OnCollisionExit2D(Collision2D col)
    {
        isGrounded = false;
    }
}
