using System;
using System.Collections;
using UnityEngine;

public class TimeManager : Singleton<TimeManager>
{

    public int CurrentHour { get; private set; } = 6;
    public int CurrentDay { get; private set; } = 1;

    public CalendarDate calendarDate;
    protected override void Init()
    {
        calendarDate = new CalendarDate(new WeekdayCalculator(), new MonthCalculator(), new SeasonCalculator());
        StartCoroutine(TimeTick());
        EventBus<HourPassedEvent>.Publish(new HourPassedEvent(CurrentHour));
    }

    private void AdvanceHour()
    {
        CurrentHour++;
        if (CurrentHour >= 24)
        {
            CurrentHour = 0;
            CurrentDay++;
            EventBus<DayPassedEvent>.Publish(new DayPassedEvent());
        }
        EventBus<HourPassedEvent>.Publish(new HourPassedEvent(CurrentHour));
    }

    public void ResetDay()
    {
        CurrentHour = 6;
        CurrentDay++;
        EventBus<DayPassedEvent>.Publish(new DayPassedEvent());
    }

    private IEnumerator TimeTick()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            AdvanceHour();
        }
    }
}
public enum TimePeriod
{
    AM,
    PM
}
