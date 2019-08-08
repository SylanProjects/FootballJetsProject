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
    public void Update()
    {
        
    }
    private void GetState()
    {
        stateController = this.gameObject.GetComponent<AIStateController>();
    }
    public void Run()
    {

    }
    public void RunZeroPosition()
    {

    }
    public void RunOnePosition()
    {

    }
    public void RunTwoPosition()
    {

    }
    public void RunThreePosition()
    {

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
        PickupActivator closestPickup = new PickupActivator();
        float closestDistance = 0;
        foreach (PickupActivator pickup in aIController.GetPickupList().GetActivePickups())
        {
            float distance = AICalculate.CalculateLengthBetween(player, pickup.GetComponent<Transform>().position.x, pickup.GetComponent<Transform>().position.y);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestPickup = pickup;
            }
        }
        return new Vector2(closestPickup.GetComponent<Transform>().position.x, closestPickup.GetComponent<Transform>().position.y);
    }
    public bool CheckIfFarFromBall()
    {
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
        if (distanceFromBall < 1)
        {
            return true;
        }
        return false;
    }
    public bool CheckOpponentsHealth()
    {
        // This methods checks if oppoent has low health
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
