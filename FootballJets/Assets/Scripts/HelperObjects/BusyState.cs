using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusyState : MonoBehaviour
{
    private bool state;
    private int timer; 
    /*
     * State deals with the issues which come up when various items are used at once.
     * false means that the player is not busy, true means that the player is busy.
     */
    private void Start()
    {
        this.state = false;
        this.timer = 0;
    }
    public void Update()
    {
        if (timer > 0)
        {
            timer -= 1;
        }
        else
        {
            timer = 0;
            this.state = false;
        }
    }
    public void SetState(bool s)
    {
        this.state = s;
        if (s == true && timer == 0)
        {
            timer = 100;
        }
    }
    public bool GetState()
    {
        return this.state;
    }
}
