using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICalculate
{

    public static float CalculateLengthBetween(GameObject o1, GameObject o2)
    {
        /*This method calculates the length between two objects.
         */
        float x1 = o1.transform.position.x;
        float y1 = o1.transform.position.y;
        float x2 = o2.transform.position.x;
        float y2 = o2.transform.position.y;

        return Mathf.Sqrt((Mathf.Pow((x2 - x1), 2) + Mathf.Pow((y2 - y1), 2)));
    }
    public static float CalculateLengthBetween(GameObject o1, float x2, float y2)
    {
        /*This method calculates the length between an object and a point.
         */
        float x1 = o1.transform.position.x;
        float y1 = o1.transform.position.y;

        return Mathf.Sqrt((Mathf.Pow((x2 - x1), 2) + Mathf.Pow((y2 - y1), 2)));
    }
    public static float CalculateLengthBetween(float x1, float y1, float x2, float y2)
    {
        /*This method calculates the length between two points.
         */
        return Mathf.Sqrt((Mathf.Pow((x2 - x1), 2) + Mathf.Pow((y2 - y1), 2)));
    }
}
