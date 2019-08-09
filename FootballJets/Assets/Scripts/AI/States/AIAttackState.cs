﻿using System.Collections;
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

        AIHelperMethods.ChooseRunMethod(this, position);


        debug.text = "Pickup: " + GetClosestPickup().ToString();

    }
    public new void RunZeroPosition()
    {
        /* OGoal | Ball | Player, AI | AIGoal
         */
        if (CheckIfFarFromBall())
        {
            // If close to a pickup - move towards it
            
            if (aIController.lineOfSight.CheckIfBallSpotted())
            {
                AIMovementBehaviour.LookAt(player, ball);
                AIBasicBehaviour.UseGun(player);
                AIMovementBehaviour.MoveTowards(player, ball);
            }
            else if (CheckIfCloseToPickup())
            {
                AIMovementBehaviour.LookAt(player, GetClosestPickup());
                AIMovementBehaviour.MoveForward(player);
            }
            else
            {
                AIGlobalBehaviour.PositionAndShoot(player, ball, aIController.lineOfSight.GetAvailablePoint());
            }
        }
        else
        {
            if (aIController.lineOfSight.CheckIfWallSpotted())
            {
                AIGlobalBehaviour.ShootInTheMiddle(player, ball, goal);
            }
            else
            {
                AIGlobalBehaviour.PositionAndShoot(player, ball, aIController.lineOfSight.GetAvailablePoint());
            }
        }
    }
    public new void RunOnePosition()
    {
        /* OGoal | AI | Ball | Player | AIGoal
         */
        if (CheckIfFarFromBall())
        {
            if (CheckIfCloseToPickup())
            {
                AIMovementBehaviour.LookAt(player, GetClosestPickup());
                AIMovementBehaviour.MoveForward(player);
            }
            else 
            {
                AIMovementBehaviour.LookAt(player, opponent);
                AIBasicBehaviour.UseGun(player);
                AIMovementBehaviour.MoveTowards(player, ball);
            }
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
        if (CheckIfFarFromBall())
        {
            if (CheckIfCloseToOpponent())
            {
                AIMovementBehaviour.LookAt(player, opponent);
                AIBasicBehaviour.UseSword(player);
                AIMovementBehaviour.MoveTowards(player, ball);
            }
            else if (CheckOpponentsHealth())
            {
                AIMovementBehaviour.LookAt(player, opponent);
                AIBasicBehaviour.UseGun(player);
                AIMovementBehaviour.MoveTowards(player, ball);
            }
            else
            {
                AIMovementBehaviour.LookAt(player, ball);
                AIBasicBehaviour.UseGun(player);
                AIMovementBehaviour.MoveTowards(player, ball);
            }
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
         
        if (CheckIfFarFromBall())
        {
            if (CheckIfCloseToOpponent())
            {
                AIMovementBehaviour.LookAt(player, opponent);
                AIBasicBehaviour.UseSword(player);
                AIMovementBehaviour.MoveTowards(player, ball);
            }
            else if (CheckOpponentsHealth())
            {
                AIMovementBehaviour.LookAt(player, opponent);
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
            // Move towards the ball as fast as possible.
            AIGlobalBehaviour.PositionAndShoot(player, ball, goal);
        }
    }

}
