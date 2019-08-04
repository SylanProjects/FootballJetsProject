using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AIGlobalBehaviour
{
    /*
     * A proxy for the Control script but this class is able to use
     * any player game object. 
     */
    
    public static Vector2 FindPointBetween(GameObject player, GameObject ball, GameObject goal)
    {
        /* First find the angle from the ball to the player (playerAngle), 
         * and from the ball to the goal (goalAngle).
         * These points are used to guide the player around the ball thus, a counter
         * value is needed, in this case r that goes from 0 to 1. 
         * The position of the point in which the player should move will keep circling
         * the ball. Imagine an arrow a few pixels away from the ball, playerAngle would make it
         * point in the direction of the player, and goalAngle would make it point
         * to the goal (we want to move player to the other side of that point so the ball is 
         * between the player and the goal).
         */

        float ar = player.GetComponent<Counter>().a;
        double goalAngle = AIDirectionBehaviour.GetAngle(ball, goal, 1);
        double playerAngle = AIDirectionBehaviour.GetAngle(ball, player, -1);

        /* To make sure that if the player (AI) is "under" the ball, it does not circle
         * the whole ball to get to the goalAngle position, this part was needed.
         * Since the bottom (0, -1) of the ball is 0 going to the left or 6.3 going to the right
         * i.e. the point where the angle resets, 6.3 is added to move that point to the left 
         * side of the ball. 
         */

        Vector2 playerDes = AIDirectionBehaviour.GetRadians(playerAngle);
        Vector2 playerPos = AIDirectionBehaviour.FindPositionOf(ball, playerDes);
        if (playerPos.x > player.transform.position.x && playerPos.y > player.transform.position.y)
        {
            playerAngle += 6.3;
        }
        float nAngle = (float)playerAngle * (1-ar) + (float)goalAngle * ar;
        Vector2 des = AIDirectionBehaviour.GetRadians(nAngle, 1.2f);
        Vector2 pos = AIDirectionBehaviour.FindPositionOf(ball, des);

        return new Vector2(pos.x, pos.y);

    }
    
    public static void PositionInFrontOf(GameObject player, GameObject ball, GameObject goal)
    {
        /* This method position the player in front of the given object.
         * It is mainly used to position the player in front of the ball in such a way that the ball is 
         * between the player and the goal.
         */ 

        Vector2 coordinates = FindPointBetween(player, ball, goal);

        /* Now we know what is the position of the point that the player will move towards.
         * Next we need to move the player towards that point. 
         */
        AIMovementBehaviour.MoveTowards(player, coordinates.x, coordinates.y);
    }
    
    public static Vector2 AvoidTheBall(GameObject player, GameObject ball, GameObject goal, float r)
    {
        double goalAngle = AIDirectionBehaviour.GetAngle(ball, goal, 1);
        double playerAngle = AIDirectionBehaviour.GetAngle(ball, player, -1);

        float nAngle = (float)playerAngle * (1 - r) + (float)goalAngle * r;

        Vector2 des = AIDirectionBehaviour.GetRadians(nAngle, 2 - (r ));
        return AIDirectionBehaviour.FindPositionOf(ball, des);
    }
    

    public static void PushBall(GameObject player, GameObject ball, GameObject goal)
    {
        Vector2 goalDirection = AIDirectionBehaviour.FindPositionOf(ball, goal, 0.9f);
        AIMovementBehaviour.LookAt(player, ball);
        if ( AICalculate.CalculateLengthBetween(player, goalDirection.x, goalDirection.y) > 0.3)
        {
            PositionInFrontOf(player, ball, goal);
        }
        else
        {
            AIMovementBehaviour.MoveForward(player);  
        }
    }
    public static void ShootAtGoal(GameObject player, GameObject ball, GameObject goal)
    {
        Vector2 goalDirection = AIDirectionBehaviour.FindPositionOf(ball, goal, 0.9f);
        AIMovementBehaviour.LookAt(player, ball);
        if (AICalculate.CalculateLengthBetween(player, goalDirection.x, goalDirection.y) > 0.3)
        {
            PositionInFrontOf(player, ball, goal);
        }
        else
        {
            AIBasicBehaviour.UseSword(player);
            AIMovementBehaviour.MoveForward(player);
        }
    }
    public static void ShootInTheMiddle(GameObject player, GameObject ball, GameObject goal)
    {
        Vector2 goalDirection = AIDirectionBehaviour.FindPositionOf(ball, goal, 0.9f);
        AIMovementBehaviour.LookAt(player, ball);
        if (AICalculate.CalculateLengthBetween(player, goalDirection.x, goalDirection.y) > 0.3)
        {
            PositionInFrontOf(player, ball, goal);
        }
        else
        {
            AIMovementBehaviour.LookAt(player, player.transform.position.x, player.GetComponent<PlayerController>().globalSettings.stateBoundary);
            AIBasicBehaviour.UseSword(player);
            
        }
    }


    
    
    


    





}
