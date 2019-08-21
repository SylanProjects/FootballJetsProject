using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AIDefendState : AIState
{
    public new void Run()
    {

        /* if the ball is not in between this player and the opposite goal
         * position in front of the goal to block the other player from scoring a goal
         * 
         * if this player is not close to a goal and the ball is in front of the goal, 
         * and if shooting the ball would not cause it to score a goal for the opposite team, shoot it
         * 
         * if the ball is close to the player, use sword to kick it away
         * if the ball is further away, shoot it
         * 
         * if the ball is on the side and there is a pickup available close, pick it up
         * the lower the health / stamina points - the more likely it is for this player get a pickup
         * 
         * shoot the player of opposite if he has a low hp and this player is blocking the goal
         * 
         * use shield to block the goal 
         * 
         * if the ball is approaching (check velocity etc.) use shield to block it 
         * 
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
            AIBasicBehaviour.Sprint(player, 1);
            AIMovementBehaviour.LookAt(player, ball);
            AIBasicBehaviour.UseGun(player);
            AIGlobalBehaviour.PositionAndShoot(player, ball, goal);

        }
        else
        {
            if (CheckIfBallApproaching())
            {
                AIBasicBehaviour.UseShield(player);
            }
            AIGlobalBehaviour.PositionAndShoot(player, ball, goal);
        }
    }
    public new void RunOnePosition()
    {
        /* OGoal | AI | Ball | Player | AIGoal
         */
        if (AICheckBehaviour.FarFromBall(player, ball))
        {
            AIGlobalBehaviour.PositionAndShoot(player, ball, goal);
        }
        else
        {
            AIGlobalBehaviour.PositionAndShoot(player, ball, goal);
        }
    }
    public new void RunTwoPosition()
    {
        /* OGoal | Player | Ball | AI | AIGoal
         */
        if (AICheckBehaviour.FarFromBall(player, ball))
        {
            AIBasicBehaviour.Sprint(player, 1);
            AIGlobalBehaviour.PositionAndShoot(player, ball, goal);
        }
        else
        {
            if (CheckIfBallApproaching())
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
