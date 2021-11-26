using UnityEngine;

/// <summary>
/// Проверять только по IsInitialized !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
/// </summary>
public abstract class SingletonAuto<T> : MonoBehaviour, ISingleton where T : SingletonAuto<T>
{
    private static T instance;
    bool isInitialized; //Need for avoid recall from interface ISingleton.OnAwake()

    public static T Instance 
    {
        get
        {
            if (!instance)
            {
                GameObject go = new GameObject(typeof(T).FullName + "_SINGLETON");
                instance = go.AddComponent<T>();
            }
            return instance;
        }
    }
       

    protected virtual void Awake() => Initialize();

    void Initialize()
    {
        if (isInitialized)
            return;

        if (instance != null)
            Debug.LogErrorFormat("[Singleton] Trying to instantiate a second instance of singleton class {0}", GetType().Name);
        else
        {
            instance = (T)this;
            isInitialized = true;
        }
    }

    protected virtual void OnDestroy()
    {
        if (instance == this)
            instance = null;
    }

    void ISingleton.OnAwake()
    {
        Initialize();
        //Debug.Log("ISingleton:" + typeof(T).Name);
    }
}
