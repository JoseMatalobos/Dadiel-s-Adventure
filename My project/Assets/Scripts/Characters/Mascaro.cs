using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mascaro : MonoBehaviour
{
    IMovement movement;
    IJump jump;
    Rigidbody2D rbMascaro;

    public Transform groundCheckTransform;

    new string name = "Mascaro";
    float speed = 4f;
    float jumpForce = 4.5f;
    bool isGrounded;

    public void Start()
    {
        // Obtener el los componentes y asignarlos.
        CharMovement charMovement = GameObject.Find("CharMovManager").GetComponent<CharMovement>();
        CharJump charJump = GameObject.Find("CharJumpManager").GetComponent<CharJump>();

        rbMascaro = GetComponent<Rigidbody2D>();

        // Inicializar el CharMovement con el Rigidbody2D de Mascaro
        charMovement.Initialize(rbMascaro);
        charJump.Initialize(rbMascaro, groundCheckTransform);

        // Asignar a la interfaz 
        movement = charMovement;
        jump = charJump;

        isGrounded = true;

        SetMovementStats();
        SetJumpStats();
    }

    void SetMovementStats()
    {
        if (movement is CharMovement charMovement)
        {
            charMovement.name = name;
            charMovement.speed = speed;
        }
    }
    void SetJumpStats()
    {
        if (jump is CharJump charJump)
        {
            charJump.jumpForce = jumpForce;
            charJump.isGrounded = isGrounded;
        }
    }

    private void Update()
    {
        movement.Move();
        jump.Jump();
    }
}


