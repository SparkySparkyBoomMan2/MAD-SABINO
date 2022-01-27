using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton: MonoBehaviour
{
    private static Singleton Instance {get; set;}

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}