using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AITackleState : AIState
{
    public Text debug;
    public new void Run()
    {
        int position = AIHelperMethods.GetPositionStatus(player, opponent, ball, goal);
        AIHelperMethods.ChooseRunMethod(this, position);


        debug.text = "pos: " + AIHelperMethods.GetPositionStatus(player, opponent, ball, goal);
    }
    public new void RunZeroPosition()
    {
        /* OGoal | Ball | Player, AI | AIGoal
         */
    }
    public new void RunOnePosition()
    {
        /* OGoal | AI | Ball | Player | AIGoal
         */
    }
    public new void RunTwoPosition()
    {
        /* OGoal | Player | Ball | AI | AIGoal
         */
    }
    public new void RunThreePosition()
    {
        /* OGoal | Player, AI | Ball | AIGoal
         */
    }
}
