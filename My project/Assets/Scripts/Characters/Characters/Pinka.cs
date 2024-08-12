using UnityEngine;

public class Pinka : MonoBehaviour
{
    IMovement movement;
    IJump jump;
    IAnimation anim;
    Rigidbody2D rbPinka;
    Animator animPinka;
    SpriteRenderer srPinka;

    public Transform groundCheckTransform;

    new string name = "Pinka";
    float speed = 4f;
    float jumpForce = 4.5f;
    bool isGrounded;

    public void Start()
    {
        // Obtener los componentes y asignarlos.
        CharMovement charMovement = GameObject.Find("CharMovManager").GetComponent<CharMovement>();
        CharJump charJump = GameObject.Find("CharJumpManager").GetComponent<CharJump>();
        CharAnimations charAnimations = GameObject.Find("CharAnimManager").GetComponent<CharAnimations>();
        rbPinka = GetComponent<Rigidbody2D>();
        animPinka = GetComponent<Animator>();
        srPinka = GetComponent<SpriteRenderer>();

        // Inicializar los scripts con el componente de Mascaro
        charMovement.Initialize(rbPinka, srPinka);
        charJump.Initialize(rbPinka, groundCheckTransform, animPinka);
        charAnimations.Initialize(animPinka);

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

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jump.Jump();
        }
    }
}