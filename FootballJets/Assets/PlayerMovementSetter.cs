using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerMovementSetter
{
    private static float r; 

    public static float GetR()
    {
        return r;
    }
    public static void SetR(float newR)
    {
        r = newR;
    }
}
