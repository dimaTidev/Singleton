using UnityEngine;


public abstract class Singleton<T> : ASingleton<T> where T : Singleton<T>
{
    public static T Instance => instance;
}
