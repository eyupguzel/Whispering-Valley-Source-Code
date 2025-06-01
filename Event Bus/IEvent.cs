
public interface IEvent { }

public struct ClockUIEvent : IEvent
{
    public int hour;
}
public struct OnChangeScene : IEvent { }
public struct OnNewDay : IEvent {}