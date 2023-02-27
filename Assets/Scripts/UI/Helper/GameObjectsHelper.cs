using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectsHelper : MonoBehaviour
{
    /// <summary>
    /// Method finds inactive GameObjects by tag, cause Unity can't do that out of the box
    /// </summary>
    /// <param name="tag"></param>
    /// <returns></returns>
    public static GameObject FindInactiveObjectByTag(string tag)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].CompareTag(tag))
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }
}
