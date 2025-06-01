using UnityEngine;
public enum WhatSeason
{
    Summer = 1,
    Fall,
    Winter,
    Spring
}
public class SeasonCalculator : ISeasonCalculator
{
    public string GetSeason(int Month)
    {
        int season = Month % 4;
        switch (season)
        {
            case 1:
                return WhatSeason.Spring.ToString();
            case 2:
                return WhatSeason.Summer.ToString();
            case 3:
                return WhatSeason.Fall.ToString();
            case 4:
                return WhatSeason.Winter.ToString();
            default:
                return WhatSeason.Spring.ToString();
        }
    }
}
