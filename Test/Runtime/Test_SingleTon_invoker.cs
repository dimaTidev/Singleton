using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_SingleTon_invoker : MonoBehaviour
{

    void Start()
    {
        Debug.Log("singleton name: " + Test_Singleton.Instance.name); 
    }
}
