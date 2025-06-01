using System;
using UnityEngine;
using System.Collections;

public class SleepService : MonoBehaviour
{
    public static event Action OnSleep;
    private PlayerController player;

    private void Start() => player = PlayerController.Instance;
    public void HandleSleep()
    {
        player.animationController.SetAnimationStrategy(new SleepingAnimation());
        player.movementController.SetMovementStrategy(new Sleep());
        TimeManager.Instance.ResetDay();
        StartCoroutine(SleepRoutine());

    }
    private IEnumerator SleepRoutine()
    {
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(SceneManager.Instance.LoadScene(2)); // Dependency Injection olabilir

        PlayerController.Instance.movementController.RestorePreviousMovementStrategy();
        PlayerController.Instance.animationController.OnAnimationComplete();

        OnSleep?.Invoke();
    }
}
