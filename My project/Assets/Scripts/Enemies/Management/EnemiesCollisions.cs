using UnityEngine;

public class EnemiesCollisions : MonoBehaviour
{ 
    private BoxCollider2D col;
    public bool turn;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("RightCol"))
        {
            turn = true;
            Debug.Log("Has tocado el lado derecho");
        }
        else if (collision.CompareTag("LeftCol"))
        {
            turn = false;
            Debug.Log("Has tocado el lado izquierdo");
        }
    }
}
