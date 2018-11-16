using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; } //Only this class can set the value

    /// <summary>
    /// Returns true if this object is the instance.
    /// Returns false if this object is going to be deleted at the end of the frame
    /// </summary>
    protected virtual bool Awake()
    {
        if (Instance != null && Instance != this)
        {
            //destroy this gameobject because one of this type is already created
            Destroy(gameObject);
            return false;
        }
        //set the instance
        Instance = this as T;
        return true;
    }
}

