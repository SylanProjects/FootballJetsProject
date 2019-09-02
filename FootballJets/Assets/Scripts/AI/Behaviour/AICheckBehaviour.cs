using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AICheckBehaviour 
{

    public static bool CheckIfCloseToPickup(List<PickupActivator> activePickups, GameObject player)
    {
        // Look for available pickups
        foreach (PickupActivator pickup in activePickups)
        {
            float distance = AICalculate.CalculateLengthBetween(player, pickup.GetComponent<Transform>().position.x, pickup.GetComponent<Transform>().position.y);
            if (distance < 5)
            {
                return true;
            }
        }
        return false;
    }
    public static Vector2 GetClosestPickup(List<PickupActivator> activePickups, int activeCount, GameObject player)
    {
        /* This method checks if there are any active pickups in the game by getting an active pickup list
         * from the main pickup list controller. Then it checks which one is the closest 
         * and returns its position as a vector. 
         */
        PickupActivator closestPickup = null;
        float closestDistance = 100;
        if (activeCount > 0)
        {
            for (int i = 0; i < activeCount; i++)
            {
                float distance = AICalculate.CalculateLengthBetween(player, activePickups[i].GetComponent<Transform>().position.x, activePickups[i].GetComponent<Transform>().position.y);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestPickup = activePickups[i];
                }
            }
        }

        if (closestPickup == null)
        {
            return new Vector2(0, 0);
        }
        return new Vector2(closestPickup.GetComponent<Transform>().position.x, closestPickup.GetComponent<Transform>().position.y);
    }
    public static bool FarFromBall(GameObject player, GameObject ball)
    {
        // Returns bool depending on the distance from the player to the ball. 

        float distanceFromBall = AICalculate.CalculateLengthBetween(player, ball);
        int allowableDistance = player.GetComponent<PlayerController>().GetGlobalSettings().allowableDistanceFromBall;
        if (distanceFromBall > allowableDistance)
        {
            return true;
        }
        return false;
    }
    public static bool CheckIfCloseToOpponent(GameObject player, GameObject opponent)
    {
        float distanceFromBall = AICalculate.CalculateLengthBetween(player, opponent);
        if (distanceFromBall < 2)
        {
            return true;
        }
        return false;
    }
    public static bool CheckOpponentsHealth(GameObject opponent)
    {
        // This methods checks if opponent has low health
        if (opponent.GetComponent<Stats>().GetHealthStatus() < 20)
        {
            return true;
        }
        return false;

    }
    public static bool CheckIfBallApproaching(GameObject player, GameObject ball)
    {
        float distance = AICalculate.CalculateLengthBetween(player, ball);
        if (distance < 3 && distance > 2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
