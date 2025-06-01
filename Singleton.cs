using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance { get { return instance; } protected set => instance = value; }

    protected void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
            Init();
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    protected virtual void Init() { }
}
