using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAnimations : MonoBehaviour, IAnimation
{
    Animator anim;
    RuntimeAnimatorController animController;
    
    
    public void Initialize(Animator externalAnim)
    {
        anim = externalAnim;
    }
    private void Start()
    {
        animController = GetComponent<Animator>().runtimeAnimatorController;
        animController = anim.runtimeAnimatorController;
    }
    public void PlayRunAnimation() 
    {
        anim.SetBool("Running", true);
    }

    public void PlayJumpAnimation() 
    {
        anim.SetBool("Jumping", true);
    }

    void Update()
    {
        
    }
}
