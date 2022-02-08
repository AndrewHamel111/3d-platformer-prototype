using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class Utils
{
    /// <summary>
    /// Reduces the magnitude of a by b. If a is less than b, sets a to 0.
    /// </summary>
    /// <param name="value">Reference to float to change</param>
    /// <param name="delta">Amount to change value by.</param>
    public static void ReduceBy(ref float value, float delta)
    {
        delta = Mathf.Abs(delta);
        if (Mathf.Abs(value) < delta)
        {
            value = 0.0f;
        }
        else
        {
            value -= delta * Mathf.Sign(value);
        }
    }

    public static float AbsClamp(float a, float min, float max)
    {
        if (a < 0.0f)
            return Mathf.Clamp(a, -max, -min);
        else
            return Mathf.Clamp(a, min, max);
    }

    internal static bool CheckPointInScreen(Vector2 position)
    {
        return position.x > 0 && position.y > 0 && position.x < Screen.width && position.y < Screen.height;
    }
}
