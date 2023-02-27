using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ColorHelper : MonoBehaviour
{
    private static int sign = 1;

    /// <summary>
    /// Loops the given value between 0 and 1.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static float GetColorValue(float value)
    {
        CheckSign(value, 0, 1);
        return (value + sign * 0.001f) % Mathf.PI;
    }

    private static void CheckSign(float value, float min, float max)
    {
        if (value >= max)
        {
            sign = -1;
            return;
        }
        if (value <= min)
            sign = 1;
    }
}
