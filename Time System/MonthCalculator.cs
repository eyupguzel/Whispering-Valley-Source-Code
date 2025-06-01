using UnityEngine;

public enum Month
{
    January = 1,
    February,
    March,
    April,
    May,
    June,
    July,
    August,
    September,
    October,
    November,
    December
}
public class MonthCalculator : IMonthCalculator
{
    public string GetMonth(int month)
    {
        int monthNumber = month % 12;
        return monthNumber switch
        {
            1 => Month.January.ToString(),
            2 => Month.February.ToString(),
            3 => Month.March.ToString(),
            4 => Month.April.ToString(),
            5 => Month.May.ToString(),
            6 => Month.June.ToString(),
            7 => Month.July.ToString(),
            8 => Month.August.ToString(),
            9 => Month.September.ToString(),
            10 => Month.October.ToString(),
            11 => Month.November.ToString(),
            0 => Month.December.ToString(),
            _ => Month.January.ToString()
        };
    }
}
