using UnityEngine;

public abstract class ASingleton<T> : MonoBehaviour, ISingleton where T : ASingleton<T>
{
    protected static T instance;
    bool isInitialized; //Need for avoid recall from interface ISingleton.OnAwake()

    protected virtual void Awake() => Initialize();

    void Initialize()
    {
        if (isInitialized)
            return;

        if (instance != null)
        {
            if (instance != this)
                Debug.LogErrorFormat("[Singleton] Trying to instantiate a second instance of singleton class {0}", GetType().Name);
        }  
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

    void ISingleton.OnAwake() => Awake(); // Debug.Log("ISingleton:" + typeof(T).Name + " instance id:" + gameObject.GetInstanceID());
}
