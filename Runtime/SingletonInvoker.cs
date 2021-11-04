using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SingletonInvoker : MonoBehaviour
{
    private void Awake()
    {
        // var ss = FindObjectsOfType<MonoBehaviour>().OfType<ISingleton>(); //didn't see hiden objects

        // var ss = Resources.FindObjectsOfTypeAll<MonoBehaviour>().OfType<ISingleton>(); //Loaded gameObject in scene and same prefab from resources at one time!!!
        // foreach (ISingleton s in ss)
        //     s.OnAwake(); 

        var ss = Resources.FindObjectsOfTypeAll<MonoBehaviour>().OfType<ISingleton>().OfType<MonoBehaviour>();
        foreach (MonoBehaviour s in ss)
        {
            if (s is ISingleton singl && s.gameObject.scene.IsValid()) //Fix bug with find: 'gameObject in scene' and 'prefab from Resources' folder. Just filter it with exist in scene
                singl.OnAwake();
        }
    }
}
