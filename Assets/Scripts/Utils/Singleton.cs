using UnityEngine;

public abstract class Singleton<T>
    where T : new()
{
    private static T _instance;
    private static object _lock = new object();
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                // 上锁，防止重复实例化
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new T();
                    }
                }
            }
            return _instance;
        }
    }
}

public class UnitySingleton<T> : MonoBehaviour
    where T : Component
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                // 利用反射创建 Unity 物体
                _instance = FindObjectOfType(typeof(T)) as T;
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.hideFlags = HideFlags.HideAndDontSave;
                    // 利用反射创建 Unity 组件
                    _instance = obj.AddComponent(typeof(T)) as T;
                }
            }
            return _instance;
        }
    }

    public virtual void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (_instance == null)
        {
            _instance = this as T;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
