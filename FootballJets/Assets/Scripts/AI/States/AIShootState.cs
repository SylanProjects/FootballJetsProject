using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIShootState : AIState
{
    public Text debug;

    
    
    public new void Run()
    {
        /* If the ball is in the corner, move it in the middle so a shot can be taken 
         * easily. First calculate the point where the ball cannot
         * be shot at the goal, and then push it back to the middle. 
         * If the ball is ready, shoot it at the goal. 
         * TODO
         * If the player is far from the ball, he can shoot it with a gun
         * to push it into the goal. 
         */

        if (aIController.lineOfSight.CheckIfWallSpotted())
        {
            
            AIGlobalBehaviour.ShootInTheMiddle(player, ball, goal);
        }
        else
        {
            AIGlobalBehaviour.ShootAtGoal(player, ball, aIController.lineOfSight.GetAvailablePoint());
        }

        int position = AIHelperMethods.GetPositionStatus(player, opponent, ball, goal);

        AIHelperMethods.ChooseRunMethod(this, position);


        //debug.text = "pos: " + AIHelperMethods.GetPositionStatus(player, opponent, ball, goal);
        debug.text = CheckIfFarFromBall() + "  balLSpotted: " + aIController.lineOfSight.CheckIfBallSpotted();

    }
    public new void RunZeroPosition()
    {
        /* OGoal | Ball | Player, AI | AIGoal
         */
        if (CheckIfFarFromBall())
        {

        }
        else
        {

        }
    }
    public new void RunOnePosition()
    {
        /* OGoal | AI | Ball | Player | AIGoal
         */
        if (CheckIfFarFromBall())
        {

        }
        else
        {

        }
    }
    public new void RunTwoPosition()
    {
        /* OGoal | Player | Ball | AI | AIGoal
         */
        if (CheckIfFarFromBall())
        {

        }
        else
        {

        }
    }
    public new void RunThreePosition()
    {
        /* OGoal | Player, AI | Ball | AIGoal
         */
        if (CheckIfFarFromBall())
        {

        }
        else
        {

        }
    }
}
