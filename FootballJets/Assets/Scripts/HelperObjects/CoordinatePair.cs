using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinatePair : MonoBehaviour
{
    private float x;
    private float y;
    public CoordinatePair(float x, float y)
    {
        this.x = x;
        this.y = y;
    }
    public float GetX()
    {
        return this.x;
    }
    public float GetY()
    {
        return this.y;
    }

    public Vector2 GetVector() 
    {
        return new Vector2(this.x, this.y);

    }
}
