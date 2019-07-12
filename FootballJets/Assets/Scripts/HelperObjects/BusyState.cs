using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusyState : MonoBehaviour
{
    private bool state;
    /*
     * State deals with the issues which come up when various items are used at once.
     * false means that the player is not busy, true means that the player is busy.
     */
    private void Start()
    {
        this.state = false;
    }
    public void SetState(bool s)
    {
        this.state = s;
    }
    public bool GetState()
    {
        return this.state;
    }
}
