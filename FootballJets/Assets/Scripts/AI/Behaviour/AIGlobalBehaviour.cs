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
         * MoveTowards does not require the player character to look in the 
         * certain direction so looking and moving can be done separately. 
         */
        AIMovementBehaviour.MoveTowards(player, coordinates.x, coordinates.y);
    }


    // Should be used as the default behaviour. 
    public static void PositionAndShoot(GameObject player, GameObject ball, GameObject goal)
    {
        /* First a position of the goal is found, then player is rotated to face the ball. 
        * Next distance from the player to the point from which he would be able to shoot is found.
        * Then the player is moved closer to it or uses a sword to shot at the goal. */
        AIMovementBehaviour.LookAt(player, ball);

        Vector2 goalDirection = AIDirectionBehaviour.FindPositionOf(ball, goal, 0.9f); // The point where player should position itself
        if (AICalculate.CalculateLengthBetween(player, ball.transform.position.x, ball.transform.position.y) < 2) // If player is close to the ball
        {
            if (AICalculate.CalculateLengthBetween(player, goalDirection.x, goalDirection.y) > 0.3)
            {
                PositionInFrontOf(player, ball, goal);
            }
            else
            {
                AIBasicBehaviour.UseSword(player);
            }
        }
        else {AIMovementBehaviour.MoveForward(player);} 
    }
    public static void ShootInTheMiddle(GameObject player, GameObject ball, GameObject goal)
    {
        /* Same as ShootAtGoal method but this time the player kicks the towards the middle of
         * the football pitch. 
         */
        Vector2 goalDirection = AIDirectionBehaviour.FindPositionOf(ball, goal, 0.9f);
        AIMovementBehaviour.LookAt(player, ball);
        if (AICalculate.CalculateLengthBetween(player, ball.transform.position.x, ball.transform.position.y) < 2) // If player is close to the ball
        {
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
        else { AIMovementBehaviour.MoveForward(player); }
    }
    




}
