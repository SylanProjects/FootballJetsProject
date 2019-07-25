using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    private string state;
    private string previousState;

    public void Start()
    {
        state = "idle";
        previousState = "idle";
    }
    public void SetState(string s)
    {
        previousState = state;
        state = s;
        
    }
    public string GetState()
    {
        return state;
    }
    public string GetPreviousState()
    {
        return previousState;
    }
}
