using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AITackleState : AIState
{
    public Text debug;
    public new void Run()
    {
        debug.text = "Tackle State" + stateController.name;
        AIGlobalBehaviour.PushBall(player, ball);
    }
    
}
