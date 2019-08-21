using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AIState : MonoBehaviour
{
    /* Base class that each state extends, not necessarily needed
     * but helps in reading and understanding the code.
     */
     
    protected AIStateController stateController;
    protected GameObject player, ball, goal, opponent;
    protected AIController aIController;
    

    public void Start()
    {
        GetState();
        player = stateController.aIController.GetPlayerObject();
        ball = stateController.aIController.GetBallObject();
        goal = stateController.aIController.GetOppositeGoal();
        opponent = stateController.aIController.GetOpponent();
        aIController = stateController.aIController;
    }
   
    private void GetState()
    {
        stateController = this.gameObject.GetComponent<AIStateController>();
    }
    public void Run(){}
    public void RunZeroPosition(){}
    public void RunOnePosition(){}
    public void RunTwoPosition(){}
    public void RunThreePosition(){}
    public void RunDefault()
    {
        /* If everything else fails, run to the ball and use the sword to shoot the ball at the goal.
         */
        AIGlobalBehaviour.PositionAndShoot(player, ball, goal);
    }
    public bool CheckIfCloseToPickup()
    {
        // Look for available pickups
        foreach (PickupActivator pickup in aIController.GetPickupList().GetActivePickups())
        {
            float distance = AICalculate.CalculateLengthBetween(player, pickup.GetComponent<Transform>().position.x, pickup.GetComponent<Transform>().position.y);
            if (distance < 5)
            {
                return true;
            }
        }
        return false;
    }
    public Vector2 GetClosestPickup()
    {
        /* This method checks if there are any active pickups in the game by getting an active pickup list
         * from the main pickup list controller. Then it checks which one is the closest 
         * and returns its position as a vector. 
         */
        PickupActivator closestPickup = null;
        float closestDistance = 100;
        List<PickupActivator> activePickups = aIController.GetPickupList().GetActivePickups();

        int activeCount = aIController.GetPickupList().GetActiveCount();
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
    public bool CheckIfFarFromBall()
    {
        // Returns bool depending on the distance from the player to the ball. 
         
        float distanceFromBall = AICalculate.CalculateLengthBetween(player, ball);
        if (distanceFromBall > aIController.GetGlobalSettings().allowableDistanceFromBall)
        {
            return true;
        }
        return false;
    }
    public bool CheckIfCloseToOpponent()
    {
        float distanceFromBall = AICalculate.CalculateLengthBetween(player, opponent);
        if (distanceFromBall < 2)
        {
            return true;
        }
        return false;
    }
    public bool CheckOpponentsHealth()
    {
        // This methods checks if opponent has low health
        if (opponent.GetComponent<Stats>().GetHealthStatus() < 20)
        {
            return true;
        }
        return false;
        
    }
    public bool CheckIfBallApproaching()
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
