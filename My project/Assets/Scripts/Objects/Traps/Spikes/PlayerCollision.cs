using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    IAnimation anim;
    private Animator animator;
    void Start()
    {
        anim = GameObject.Find("CharAnimManager").GetComponent<IAnimation>();
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player") 
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.gameObject.GetComponent<Rigidbody2D>().velocity.x, 4f);
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            anim.PlayHitAnimation();
        }
    }
}
