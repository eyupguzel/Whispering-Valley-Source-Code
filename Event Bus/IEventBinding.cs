using System;
using UnityEngine;

public interface IEventBinding<T>
{
    public  Action<T> OnEvent { get;set; }
    public  Action OnEventNoArgs { get; set; }
}

public class EventBinding<T> : IEventBinding<T> where T : IEvent
{
    private Action<T> OnEvent = _ => { };
    private Action OnEventNoArgs = () => { };

    //Sadece arayüz üzerinden ulaþmak istiyorsak 'interface implementation' kullanýrýz.
    Action<T> IEventBinding<T>.OnEvent
    {
        get => OnEvent;
        set => OnEvent = value;
    }
    Action IEventBinding<T>.OnEventNoArgs
    {
        get => OnEventNoArgs;
        set => OnEventNoArgs = value;
    }
    public EventBinding(Action<T> OnEvent) => this.OnEvent = OnEvent;
    public EventBinding(Action OnEventNoArgs) => this.OnEventNoArgs = OnEventNoArgs;

    public void Add(Action<T> action) => OnEvent += action;
    public void Remove(Action<T> action) => OnEvent -= action;

    public void Add(Action action) => OnEventNoArgs += action;
    public void Remove(Action action) => OnEventNoArgs -= action;

}
