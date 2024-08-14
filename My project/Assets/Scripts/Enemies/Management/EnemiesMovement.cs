using UnityEngine;

public class EnemiesMovement : MonoBehaviour, IEnemMovement
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    public float speed;
    
    private EnemiesCollisions enemiesCollisions;
    public void Initialize(Rigidbody2D externalRb, SpriteRenderer externalSr)
    {
        rb = externalRb;
        sr = externalSr;
    }

    private void Start()
    {
        enemiesCollisions = GameObject.FindWithTag("Enemy").GetComponent<EnemiesCollisions>();
    }

    public void EnemMovement() 
    {
        bool enemTurn = enemiesCollisions.turn;

        if (enemTurn == true)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            sr.flipX = false;
        } else if (enemTurn == false) 
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            sr.flipX = true;
        }
    }
}
