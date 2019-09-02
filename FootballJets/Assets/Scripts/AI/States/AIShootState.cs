using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIShootState : AIState
{
   
    public new void Run()
    {
        /* If the ball is in the corner, move it in the middle so a shot can be taken 
         * easily. First calculate the point where the ball cannot
         * be shot at the goal, and then push it back to the middle. 
         * If the ball is ready, shoot it at the goal. 
         */

        

        int position = AIHelperMethods.GetPositionStatus(player, opponent, ball, goal);
        switch (position)
        {
            case -1:
                RunDefault();
                break;
            case 0:
                RunZeroPosition();
                break;
            case 1:
                RunOnePosition();
                break;
            case 2:
                RunTwoPosition();
                break;
            case 3:
                RunThreePosition();
                break;
        }


    }
    public new void RunZeroPosition()
    {
        /* OGoal | Ball | Player, AI | AIGoal
         */
        if (AICheckBehaviour.FarFromBall(player, ball))
        {
            if (aIController.lineOfSight.CheckIfBallSpotted())
            {
                AIMovementBehaviour.LookAt(player, ball);
                AIBasicBehaviour.UseGun(player);
            }
            
        }
        if (aIController.lineOfSight.CheckIfWallSpotted())
        {
            AIGlobalBehaviour.ShootInTheMiddle(player, ball, goal);
        }
        else
        {
            AIGlobalBehaviour.PositionAndShoot(player, ball, aIController.lineOfSight.GetAvailablePoint());
        }

    }
    public new void RunOnePosition()
    {
        /* OGoal | AI | Ball | Player | AIGoal
         */
        if (AICheckBehaviour.FarFromBall(player, ball))
        {
            if (AICheckBehaviour.CheckOpponentsHealth(opponent))
            {
                AIMovementBehaviour.LookAt(player, opponent);
                AIBasicBehaviour.UseGun(player);
            }
            else if (AICheckBehaviour.CheckIfCloseToPickup(GetActivePickups(), player))
            {
                AIMovementBehaviour.LookAt(player, AICheckBehaviour.GetClosestPickup(GetActivePickups(), GetActiveCount(), player));
                AIMovementBehaviour.MoveForward(player);
            }
            else
            {
                AIGlobalBehaviour.PositionAndShoot(player, ball, aIController.lineOfSight.GetAvailablePoint());
            }

        }
        else
        {
            AIGlobalBehaviour.PositionAndShoot(player, ball, aIController.lineOfSight.GetAvailablePoint());
        }
    }
    public new void RunTwoPosition()
    {
        /* OGoal | Player | Ball | AI | AIGoal
         */
        if (AICheckBehaviour.FarFromBall(player, ball))
        {
            AIBasicBehaviour.Sprint(player, 1);
            if (aIController.lineOfSight.CheckIfBallSpotted())
            {
                AIMovementBehaviour.LookAt(player, ball);
                AIBasicBehaviour.UseGun(player);
                AIMovementBehaviour.MoveTowards(player, ball);
            } 
            else
            {
                AIGlobalBehaviour.PositionAndShoot(player, ball, goal);
            }
        }
        else
        {
            if (AICheckBehaviour.CheckIfBallApproaching(player, ball))
            {
                AIBasicBehaviour.UseShield(player);
            }
            AIGlobalBehaviour.PositionAndShoot(player, ball, goal);
        }
    }
    public new void RunThreePosition()
    {
        /* OGoal | Player, AI | Ball | AIGoal
         */
        AIBasicBehaviour.Sprint(player, 1);
        AIGlobalBehaviour.PositionAndShoot(player, ball, goal);

    }
}
