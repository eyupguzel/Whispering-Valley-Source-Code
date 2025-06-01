using UnityEngine;

public class SleepingAnimation : IAnimationStrategy
{
    public void PlayAnimation(Animator animator, Vector2 input)
    {
        animator.SetBool("IsSleep",true);
    }
    public void OnAnimationEnd(Animator animator)
    {
        animator.SetBool("IsSleep",false);
    }
}


