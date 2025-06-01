using UnityEngine;

public interface IAnimationStrategy
{
    void PlayAnimation(Animator animator, Vector2 input);
    void OnAnimationEnd(Animator animator);
}
