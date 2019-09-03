using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIController : MonoBehaviour
{
    
    public GameObject ball, player, opponent;

    public Text debug;
    public PlayerConfig playerConfig;
    public GlobalSettings globalSettings;
    public StateController stateController;

    public AIDefendState defendState;
    public AITackleState tackleState;
    public AIAttackState attackState;
    public AIShootState shootState;

    public AILineOfSight lineOfSight;

    public PickupList pickupList;
    private float xPos;
    private float boundary;


    private Controls controller;
    public void Start()
    {
        controller = player.gameObject.GetComponent<Controls>();
        FixedUpdate();
        xPos = 0;
        boundary = player.GetComponent<PlayerController>().team.GetStateBoundary();
    }
    public void FixedUpdate()
    {
        /* First find the position of the ball on the x axis and than compare it 
         * with the state boundary which is the point where the states meet. 
         * There is no need to make different states for the y axis since 
         * the AI should change its behaviour based on how far away/close he is
         * from its own and from the opponents goal.
         */
        
        AIBasicBehaviour.Sprint(player, 0);

        xPos = ball.transform.position.x;
        if (xPos >= boundary)
        {
            defendState.Run();
        }
        else if (xPos < boundary && xPos > 0)
        {
            tackleState.Run();
        }
        else if (xPos < 0 && xPos > -boundary)
        {
            attackState.Run();
        }
        else if (xPos <= -boundary)
        {
            shootState.Run();
        }
    }
   
    public GameObject GetPlayerObject()
    {
        return player;
    }
    public GameObject GetBallObject()
    {
        return ball;
    }
    public GameObject GetOppositeGoal()
    {
        return player.GetComponent<PlayerController>().team.opponentGoal;
    }
    public GameObject GetOpponent()
    {
        return opponent;
    }
    public GlobalSettings GetGlobalSettings()
    {
        return globalSettings;
    }
    public PickupList GetPickupList()
    {
        return pickupList;
    }

}
