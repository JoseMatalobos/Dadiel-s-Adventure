using UnityEngine;

public class Raninja : MonoBehaviour
{
    IMovement movement;
    IJump jump;
    IAnimation anim;
    Rigidbody2D rbRaninja;
    Animator animRaninja;
    SpriteRenderer srRaninja;

    public Transform groundCheckTransform;

    new string name = "Raninja";
    float speed = 4f;
    float jumpForce = 4.5f;
    bool isGrounded;

    public void Start()
    {
        // Obtener los componentes y asignarlos.
        CharMovement charMovement = GameObject.Find("CharMovManager").GetComponent<CharMovement>();
        CharJump charJump = GameObject.Find("CharJumpManager").GetComponent<CharJump>();
        CharAnimations charAnimations = GameObject.Find("CharAnimManager").GetComponent<CharAnimations>();
        rbRaninja = GetComponent<Rigidbody2D>();
        animRaninja = GetComponent<Animator>();
        srRaninja = GetComponent<SpriteRenderer>();

        // Inicializar los scripts con el componente de Mascaro
        charMovement.Initialize(rbRaninja, srRaninja);
        charJump.Initialize(rbRaninja, groundCheckTransform, animRaninja);
        charAnimations.Initialize(animRaninja);

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