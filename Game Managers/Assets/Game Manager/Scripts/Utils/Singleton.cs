using System;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    public static T instance { get; private set; }
    public static bool isInitialized => instance != null;

    protected virtual void Awake()
    {
        if (instance != null)
        {
            Debug.Log("[Singleton] Trying to instantiate a second instance of a singleton class." );
        }
        else
        {
            instance = (T) this;
        }
    }

    protected virtual void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
}
