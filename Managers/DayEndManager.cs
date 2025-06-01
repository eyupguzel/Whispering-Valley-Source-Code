using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class DayEndManager : MonoBehaviour
{
    private TextMeshProUGUI dayText;

    private void Start()
    {
        dayText = transform.Find("dayText").GetComponent<TextMeshProUGUI>();
        StartCoroutine(GameScene());
        UpdateText();
    }
    
    private void UpdateText()
    {
        dayText.text = $"- Day {TimeManager.Instance.CurrentDay} -";
    }

    private IEnumerator GameScene()
    {
        yield return new WaitForSeconds(3.5f);
        StartCoroutine(SceneManager.Instance.LoadScene(1));
    }
}
