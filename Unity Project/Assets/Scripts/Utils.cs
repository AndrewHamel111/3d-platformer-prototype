using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    public static void ReduceBy(ref float a, float b)
    {
        b = Mathf.Abs(b);
        if (Mathf.Abs(a) < b)
            a = 0.0f;

        if (a > 0.0f)
            a -= b;
        else
            a += b;
    }

    public static float AbsClamp(float a, float min, float max)
    {
        if (a < 0.0f)
            return Mathf.Clamp(a, -max, -min);
        else
            return Mathf.Clamp(a, min, max);
    }
}
