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
    public List<PickupActivator> GetActivePickups()
    {
        return aIController.GetPickupList().GetActivePickups();
    }
    public int GetActiveCount()
    {
        return aIController.GetPickupList().GetActiveCount();
    }
}
