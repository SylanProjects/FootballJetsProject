using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AIGlobalBehaviour
{

    public static void PositionInFrontOf(GameObject player, GameObject ball, GameObject goal)
    {
        /* This method position the player in front of the given object.
         * It is mainly used to position the player in front of the ball in such a way that the ball is 
         * between the player and the goal.
         */ 

        Vector2 coordinates = AICalculate.FindPointBetween(player, ball, goal);

        /* Now we know what is the position of the point that the player will move towards.
         * Next we need to move the player towards that point. 
         * MoveTowards is does not require the player character to look in the 
         * certain direction so looking and moving can be done separately. 
         */
        AIMovementBehaviour.MoveTowards(player, coordinates.x, coordinates.y);
    }
    
    
    
    public static void ShootAtGoal(GameObject player, GameObject ball, GameObject goal)
    {
        /* First a position of the goal is found, then player is rotated to face the ball. 
         * Next check how far the player is from the point from which he would be able to shoot 
         * the ball into the goal. Then either move closer to that position or use a sword.
         */
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
        /* Same as ShootAtGoal method but this time the player kicks the towards the middle of 
         * the football pitch. 
         */
        Vector2 goalDirection = AIDirectionBehaviour.FindPositionOf(ball, goal, 0.9f);
        AIMovementBehaviour.LookAt(player, ball);
        if (AICalculate.CalculateLengthBetween(player, goalDirection.x, goalDirection.y) > 0.3)
        {
            PositionInFrontOf(player, ball, goal);
        }
        else
        {
            AIMovementBehaviour.LookAt(player, player.transform.position.x, player.GetComponent<PlayerController>().globalSettings.stateBoundary);
            AIBasicBehaviour.UseGun(player);
            
        }
    }
    public static void PushBall(GameObject player, GameObject ball, GameObject goal)
    {
        
        Vector2 goalDirection = AIDirectionBehaviour.FindPositionOf(ball, goal, 0.9f);
        AIMovementBehaviour.LookAt(player, ball);
        if (AICalculate.CalculateLengthBetween(player, goalDirection.x, goalDirection.y) > 0.3)
        {
            PositionInFrontOf(player, ball, goal);
        }
        else
        {
            AIMovementBehaviour.MoveForward(player);
        }
    }




}
