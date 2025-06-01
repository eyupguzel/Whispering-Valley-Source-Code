using System;
using UnityEngine;

public class CalendarDate
{
    public int CurrentDay { get; private set; } = 1;
    public int CurrentMonth { get; private set; } = 1;
    public int CurrentYear { get; private set; } = 1;

    public string day;
    public string month;
    public string season;

    private IWeekdayCalculator weekdayCalculator;
    private IMonthCalculator monthCalculator;
    private ISeasonCalculator seasonCalculator;

    private IEventBinding<DayPassedEvent> dayBinding;
    public CalendarDate(IWeekdayCalculator weekdayCalculator, IMonthCalculator monthCalculator, ISeasonCalculator seasonCalculator)
    {
        dayBinding = new EventBinding<DayPassedEvent>(UpdateDate);
        EventBus<DayPassedEvent>.Subscribe(dayBinding);

        this.weekdayCalculator = weekdayCalculator;
        this.monthCalculator = monthCalculator;
        this.seasonCalculator = seasonCalculator;

        day = weekdayCalculator.GetWeekday(CurrentDay);
        month = monthCalculator.GetMonth(CurrentMonth);
        season = seasonCalculator.GetSeason(CurrentMonth);
    }
    private void UpdateDate()
    {
        UpdateDay();
        day = weekdayCalculator.GetWeekday(CurrentDay);
        month = monthCalculator.GetMonth(CurrentMonth);
        season = seasonCalculator.GetSeason(CurrentMonth);
    }
    private void UpdateDay()
    {
        CurrentDay++;
        if (CurrentDay > 30) 
        {
            CurrentDay = 1;
            UpdateMonth();
        }
    }
    private void UpdateMonth()
    {
        CurrentMonth++;
        if (CurrentMonth > 12)
        {
            CurrentMonth = 1;
            UpdateYear();
        }
    }

    private void UpdateYear() => CurrentYear++;
}
