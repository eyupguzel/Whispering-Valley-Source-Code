using UnityEngine;
public enum WhatDay
{
    Mon = 1,
    Tue,
    Wed,
    Thu,
    Fri,
    Sat,
    Sun
}
public class WeekdayCalculator : IWeekdayCalculator
{
    public string GetWeekday(int _day)
    {
        int day = _day % 7;
        return day switch
        {
            1 => WhatDay.Mon.ToString(),
            2 => WhatDay.Tue.ToString(),
            3 => WhatDay.Wed.ToString(),
            4 => WhatDay.Thu.ToString(),
            5 => WhatDay.Fri.ToString(),
            6 => WhatDay.Sat.ToString(),
            7 => WhatDay.Sun.ToString(),
            _ => WhatDay.Mon.ToString(),
        };
    }
}
