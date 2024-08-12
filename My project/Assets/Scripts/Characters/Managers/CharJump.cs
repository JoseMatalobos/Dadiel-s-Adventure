using UnityEngine;

public class CharJump : MonoBehaviour, IJump
{
    public Transform groundCheck;
    public LayerMask groundLayer;

    public float jumpForce;
    public bool isGrounded;

    private Rigidbody2D rb;
    private Animator anim;

    IJump jump;

    public void Initialize(Rigidbody2D externalRb, Transform groundCheckTransform, Animator externalAnim)
    {
        rb = externalRb;
        groundCheck = groundCheckTransform;
        anim = externalAnim;
    }
    public void Jump() 
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        anim.SetBool("Jumping", true);
    }

    void Update()
    {
        // Detecta si el personaje está tocando el suelo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        anim.SetBool("Grounded", isGrounded);
        anim.SetBool("Jumping", !isGrounded);
    }
}
