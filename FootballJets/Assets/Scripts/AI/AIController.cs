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



    private Controls controller;
    public void Start()
    {
        controller = player.gameObject.GetComponent<Controls>();
    }
    public void FixedUpdate()
    {
        /* First find the position of the ball on the x axis and than compare it 
         * with the state boundary which is the point where the states meet. 
         * There is no need to make different states for the y axis since 
         * the AI should change its behaviour based on how far away/close he is
         * from its own and from the opponents goal.
         */
        float xPos = ball.transform.position.x;
        float b = player.GetComponent<PlayerController>().team.GetStateBoundary();

        if (xPos >= b)
        {
            defendState.Run();
        }
        else if (xPos < b && xPos > 0)
        {
            tackleState.Run();
        }
        else if (xPos < 0 && xPos > -b)
        {
            attackState.Run();
        }
        else if (xPos <= -b)
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
}
