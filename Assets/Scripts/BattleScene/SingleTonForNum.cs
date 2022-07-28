using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTonForNum : MonoBehaviour
{
    public static SingleTonForNum instance;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }


    }
}
