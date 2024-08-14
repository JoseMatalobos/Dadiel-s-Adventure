using UnityEngine;

public class CharMovement : MonoBehaviour, IMovement
{
    public new string name;
    public float speed;
    public bool isGrounded;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    IJump jump;
    IAnimation anim;
    private void Start()
    {
        CharJump charJump = GameObject.Find("CharJumpManager").GetComponent<CharJump>();
        anim = GameObject.Find("CharAnimManager").GetComponent<IAnimation>();
        jump = charJump;
    }

    public void Initialize(Rigidbody2D externalRb, SpriteRenderer externalSr)
    {
        rb = externalRb;
        sr = externalSr;
    }

    public void Move()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        if (moveInput > 0f) 
        {
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
            anim.PlayRunAnimation();
            sr.flipX = false;
        } 
        else if(moveInput < 0f) 
        {
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
            anim.PlayRunAnimation();
            sr.flipX = true;
        }
        else if(moveInput == 0f)
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
            anim.StopRunAnimation(); 
        }
    }

    void Update()
    {
        if (jump is CharJump charJump)
        {
            isGrounded = charJump.isGrounded;
        }
    }
}
