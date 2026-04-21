using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float Lspeed = 2.5f;
    private Rigidbody2D rb;
    private Animator anim;
    bool isGrounded;
    public UIUP uiManager;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            rb.linearVelocity = new Vector2(Lspeed, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
        }
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spike") || other.CompareTag("DeathZone"))
            uiManager.Damage();
    }
    void Die()
    {
        Debug.Log("Dead");
        Time.timeScale = 0f;
    }
}
