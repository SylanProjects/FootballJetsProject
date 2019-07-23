using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    private string state;

    public void Start()
    {
        state = "idle";
    }
    public void SetState(string s)
    {
        state = s;
    }
    public string GetState()
    {
        return state;
    }
}
