using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour, IMovement
{
    public new string name;
    public float speed;
    public bool isGrounded;

    private Rigidbody2D rb;

    IJump jump;

    private void Start()
    {
        CharJump charJump = GameObject.Find("CharJumpManager").GetComponent<CharJump>();
        jump = charJump;
    }

    public void Initialize(Rigidbody2D externalRb)
    {
        rb = externalRb;
    }

    public void Move()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    void Update()
    {
        if (jump is CharJump charJump)
        {
            isGrounded = charJump.isGrounded;
        }
    }
}
