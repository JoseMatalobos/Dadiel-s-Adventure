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
    public void StopRunAnimation() 
    {
        anim.SetBool("Running", false);
    }

    public void PlayJumpAnimation() 
    {
        anim.SetBool("Jumping", true);
    }

    public void StopJumpAnimation() 
    {
        anim.SetBool("Jumping", false);
    }

    public void PlayHitAnimation() 
    {
        anim.SetBool("Hitted", true);
    }
}
