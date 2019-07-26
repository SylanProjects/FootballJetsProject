using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIState : MonoBehaviour
{
    /* Base class that each state extends, not necessarily needed
     * but helps in reading and understanding the code.
     */
    protected AIStateController stateController;
    protected GameObject player;
    protected GameObject ball;
    public void Start()
    {
        GetState();
        player = stateController.aIController.GetPlayerObject();
        ball = stateController.aIController.GetBallObject();
    }
    private void GetState()
    {
        stateController = this.gameObject.GetComponent<AIStateController>();
    }
    public void Run()
    {

    }
}
