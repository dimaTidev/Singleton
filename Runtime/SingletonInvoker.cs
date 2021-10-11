using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SingletonInvoker : MonoBehaviour
{
    private void Awake()
    {
       // var ss = FindObjectsOfType<MonoBehaviour>().OfType<ISingleton>();
        var ss = Resources.FindObjectsOfTypeAll<MonoBehaviour>().OfType<ISingleton>();
        foreach (ISingleton s in ss)
            s.OnAwake(); 
    }
}
