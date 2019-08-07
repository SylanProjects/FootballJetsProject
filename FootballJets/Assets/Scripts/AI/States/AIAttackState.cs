using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIAttackState : AIState
{
    public Text debug;
    public new void Run()
    {
        
        /* When ball is in this state the AI should try and take the ball away from the player.
         * There are four positions that the ball and the players can be in. 
         * 
         */
        int position = AIHelperMethods.GetPositionStatus(player, opponent, ball, goal);
        AIHelperMethods.ChooseRunMethod(this, position);


        debug.text = "pos: " + position;

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
