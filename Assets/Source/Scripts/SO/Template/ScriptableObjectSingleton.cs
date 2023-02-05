using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScriptableObjectSingleton<T> : ScriptableObject where T : ScriptableObjectSingleton<T> 
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
                instance = Resources.FindObjectsOfTypeAll<T>().FirstOrDefault();

            return instance;
        }
    }
}
