using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIAttackState : AIState
{
    public Text debug;
    public new void Run()
    {
        debug.text = "Attack State" + stateController.name;
    }
    private void Defend()
    {

    }
    private void ShootAtTheGoal()
    {

    }
}
