using System;
using UnityEngine;

public class AnimationController : Singleton<AnimationController>
{
    public static Vector2 lastDirection;
    public static event Action OnAnimationEnd;
    public IAnimationStrategy currentAnimation;
    private IAnimationStrategy previousAnimation;

    private Animator animator;

    private void Start()
    {
        currentAnimation = new WalkingAnimation();
        animator = GetComponent<Animator>();
    }
    public void SetAnimationStrategy(IAnimationStrategy newAnimationStrategy)
    {
        if (newAnimationStrategy.GetType() != currentAnimation.GetType())
        {
            previousAnimation = currentAnimation;
            currentAnimation = newAnimationStrategy;
        }

    }
    private void RestorePreviousAnimation()
    {
        currentAnimation.OnAnimationEnd(animator);
        currentAnimation = previousAnimation;
    }
    public void OnAnimationComplete()
    {
        RestorePreviousAnimation();
        OnAnimationEnd?.Invoke();
    }

}
