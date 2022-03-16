using UnityEngine;

/// <summary>
/// Проверять только по IsInitialized !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
/// </summary>
public abstract class SingletonAuto<T> : ASingleton<T> where T : SingletonAuto<T>
{
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
}