using UnityEngine;

public class WalkingAnimation : IAnimationStrategy
{
    Vector2 lastDirection;
    public void PlayAnimation(Animator animator, Vector2 input)
    {
        if (input.magnitude > 0)
        {
            AnimationController.lastDirection = input;
            lastDirection = AnimationController.lastDirection;

            animator.SetFloat("X", input.x);
            animator.SetFloat("Y", input.y);
        }
        else
        {
            if (lastDirection.y > 0)
                animator.SetFloat("Y", 0.25f);
            else if (lastDirection.y < 0) 
                animator.SetFloat("Y", - 0.25f);
            else if (lastDirection.x > 0)
                animator.SetFloat("X", 0.25f);
            else if (lastDirection.x < 0)
                animator.SetFloat("X", -0.25f);
        }
    }

    public void OnAnimationEnd(Animator animator)
    {
    }
}
