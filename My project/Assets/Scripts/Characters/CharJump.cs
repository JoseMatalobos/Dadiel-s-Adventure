using Unity.VisualScripting;
using UnityEngine;

public class CharJump : MonoBehaviour, IJump
{
    public Transform groundCheck;
    public LayerMask groundLayer;

    public float jumpForce;
    public bool isGrounded;

    private Rigidbody2D rb;

    public void Initialize(Rigidbody2D externalRb, Transform groundCheckTransform)
    {
        rb = externalRb;
        groundCheck = groundCheckTransform;
    }
    public void Jump() 
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) 
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, 0.1f);
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }
}
