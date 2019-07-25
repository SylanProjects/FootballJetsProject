using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIShootState : AIState
{
    public Text debug;
    public new void Run()
    {
        debug.text = "Shoot State" + stateController.name;
    }
}
