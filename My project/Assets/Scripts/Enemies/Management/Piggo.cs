using UnityEngine;

public class Piggo : MonoBehaviour
{
    IEnemMovement iEnemMovement;

    Animator animPiggo;
    Rigidbody2D rbPiggo;
    SpriteRenderer srPiggo;

    float speedPigo = 2f;

    void Start()
    {
        animPiggo = GetComponent<Animator>();
        rbPiggo = GetComponent<Rigidbody2D>();
        srPiggo = GetComponent <SpriteRenderer>();

        EnemiesMovement enemMovement = GameObject.Find("EnemMovManager").GetComponent<EnemiesMovement>();

        enemMovement.Initialize(rbPiggo, srPiggo);

        iEnemMovement = enemMovement;

        SetMoveSpeed();
    }

    public void SetMoveSpeed() 
    {
        if (iEnemMovement is EnemiesMovement enemMovement)
        {
            enemMovement.speed = speedPigo;
        }
    }
    

    void Update()
    {
        if (iEnemMovement is EnemiesMovement enemMovement) 
        {
            iEnemMovement.EnemMovement();
        }
    }
}
