using UnityEngine;

public class HoeingAnimation : IAnimationStrategy
{
    Vector2 lastDirection = AnimationController.lastDirection;
    public void PlayAnimation(Animator animator, Vector2 input)
    {
        animator.SetTrigger("Hoeing");

        if (lastDirection.y > 0)
            animator.SetFloat("Y", 0.25f);
        else if (lastDirection.y < 0)
            animator.SetFloat("Y", -0.25f);
        else if (lastDirection.x > 0)
            animator.SetFloat("X", 0.25f);
        else if (lastDirection.x < 0)
            animator.SetFloat("X", -0.25f);
    }
    public void OnAnimationEnd(Animator animator)
    {
        animator.ResetTrigger("Hoeing");
    }
}
