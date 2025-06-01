using UnityEngine;

public class HourPassedEvent : IEvent
{
    public int hour;
    public HourPassedEvent(int hour) => this.hour = hour;
}
