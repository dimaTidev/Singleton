using UnityEngine;

/// <summary>
/// Проверять только по IsInitialized !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
/// </summary>
public class SingletonAuto<T> : MonoBehaviour, ISingleton where T : SingletonAuto<T>
{
    private static T instance;
  //  bool isInitialized;

    public static bool IsInitialized
    {
        get
        {
            if (instance != null)
                return true;

            GameObject go = new GameObject("SINGLETON!!!!!!!");
            instance = go.AddComponent<T>();
            return true;
        }
    }

    public static T Instance => instance;

    protected virtual void Awake() => Initialize();

    void Initialize()
    {
      //  if (isInitialized)
      //      return;

        if (instance != null)
            Debug.LogErrorFormat("[Singleton] Trying to instantiate a second instance of singleton class {0}", GetType().Name);
        else
        {
            instance = (T)this;
            //isInitialized = true;
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
