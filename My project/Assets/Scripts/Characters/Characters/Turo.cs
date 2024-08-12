using UnityEngine;

public class Turo : MonoBehaviour
{
    IMovement movement;
    IJump jump;
    IAnimation anim;
    Rigidbody2D rbTuro;
    Animator animTuro;
    SpriteRenderer srTuro;

    public Transform groundCheckTransform;

    new string name = "Turo";
    float speed = 4f;
    float jumpForce = 4.5f;
    bool isGrounded;

    public void Start()
    {
        // Obtener los componentes y asignarlos.
        CharMovement charMovement = GameObject.Find("CharMovManager").GetComponent<CharMovement>();
        CharJump charJump = GameObject.Find("CharJumpManager").GetComponent<CharJump>();
        CharAnimations charAnimations = GameObject.Find("CharAnimManager").GetComponent<CharAnimations>();
        rbTuro = GetComponent<Rigidbody2D>();
        animTuro = GetComponent<Animator>();
        srTuro = GetComponent<SpriteRenderer>();

        // Inicializar los scripts con el componente de Mascaro
        charMovement.Initialize(rbTuro, srTuro);
        charJump.Initialize(rbTuro, groundCheckTransform, animTuro);
        charAnimations.Initialize(animTuro);

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