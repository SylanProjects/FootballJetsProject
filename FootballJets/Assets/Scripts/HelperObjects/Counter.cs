using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public float a; 
    void Start()
    {
        a = 0;
    }
    void Update()
    {
        a += 0.01f;
        if (a >= 1)
        {
            a = 0;
        }
    }
}
