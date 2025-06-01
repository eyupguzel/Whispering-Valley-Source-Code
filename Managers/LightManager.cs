using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightManager : Singleton<LightManager>
{
    [SerializeField] private Gradient gradient;
    private Light2D light2D;

    private IEventBinding<HourPassedEvent> hourBindind;
    private void Start()
    {
        light2D = GetComponent<Light2D>();
        hourBindind = new EventBinding<HourPassedEvent>(UpdateLight);
        EventBus<HourPassedEvent>.Subscribe(hourBindind);
    }

    private void UpdateLight(HourPassedEvent e)
    {
        int hour = e.hour;

        float normalizedTime = (float)hour / 24;
        Color targetColor = gradient.Evaluate(normalizedTime);
        StartCoroutine(SmoothTransition(targetColor));
    }
    private IEnumerator SmoothTransition(Color targetColor)
    {
        Color startColor = light2D.color;
        float elepsedTime = 0f;

        while (elepsedTime < 2f)
        {
            elepsedTime += Time.deltaTime;
            light2D.color = Color.Lerp(startColor, targetColor, elepsedTime / 1f);
            yield return null;
        }
        light2D.color = targetColor;
    }
}
