using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClockUI : MonoBehaviour
{
    [SerializeField] private Sprite[] clockSprites;

    private Image clockImage;
    private TextMeshProUGUI clockText;
    private TextMeshProUGUI dayText;

    private CalendarDate calendarDate;

    private IEventBinding<HourPassedEvent> hourBinding;
    private IEventBinding<DayPassedEvent> dayBinding;
    private void Start()
    {
        calendarDate = TimeManager.Instance.calendarDate;
        clockText = transform.Find("clockText").GetComponent<TextMeshProUGUI>();
        dayText = transform.Find("dayText").GetComponent<TextMeshProUGUI>();
        clockImage = transform.Find("clockImage").GetComponent<Image>();

        hourBinding = new EventBinding<HourPassedEvent>(UpdateClock);
        dayBinding = new EventBinding<DayPassedEvent>(UpdateDay);

        EventBus<HourPassedEvent>.Subscribe(hourBinding);
        EventBus<DayPassedEvent>.Subscribe(dayBinding);

       // UpdateDay();
    }
    
    private void UpdateClock(HourPassedEvent e)
    {
        int hour = e.hour;
        clockText.text = $"{hour}:00 {GetTimePeriod(hour)}";

        if (hour >= 21 && hour < 24)
            clockImage.sprite = clockSprites[0]; 
        else if (hour >= 0 && hour < 5)
            clockImage.sprite = clockSprites[0];
        else if (hour >= 5 && hour < 6)
            clockImage.sprite = clockSprites[1];
        else if (hour >= 6 && hour < 12)
            clockImage.sprite = clockSprites[2];
        else if (hour >= 12 && hour < 15)
            clockImage.sprite = clockSprites[3];
        else if (hour >= 15 && hour < 18)
            clockImage.sprite = clockSprites[4];
        else if (hour >= 18 && hour < 21)
            clockImage.sprite = clockSprites[5]; 
    }

    private void UpdateDay()
    {
        dayText.text = $" {calendarDate.day}.{ calendarDate.CurrentDay}";

    }
    private void OnDestroy()
    {
        EventBus<HourPassedEvent>.Unsubscribe(hourBinding);
        EventBus<DayPassedEvent>.Unsubscribe(dayBinding);
    }
    private TimePeriod GetTimePeriod(int CurrentHour)
    {
        return CurrentHour < 12 ? TimePeriod.AM : TimePeriod.PM;
    }
}
