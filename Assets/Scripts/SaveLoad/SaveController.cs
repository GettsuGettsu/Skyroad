using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveController : MonoBehaviour
{
    public static void Save(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }

    public static int Load(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            return PlayerPrefs.GetInt(key);
        }
        return 0;
    }
}
