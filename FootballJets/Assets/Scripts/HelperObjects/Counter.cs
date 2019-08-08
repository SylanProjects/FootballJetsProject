using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    /* This class is a counter. 
     */
    public float a; 
    void Start()
    {
        a = 0;
    }
    void Update()
    {
        /* No need to use delta time since it will be used to calculate the position
         * of the point arond the ball that player object will have to follow
         * to go around the ball, so it can position in front of the ball opposite to the 
         * goal.
         */
        a += 0.01f;
        if (a >= 1)
        {
            a = 0;
        }
    }
}
