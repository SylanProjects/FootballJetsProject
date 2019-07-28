using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIController : MonoBehaviour
{
    
    public GameObject ball;
    public GameObject player;
    public GameObject ballArrow;
    public GameObject goalArrow;
    public GameObject goal;

    public Text debug;
    public PlayerConfig playerConfig;
    public GlobalSettings globalSettings;
    public StateController stateController;

    public AIDefendState defendState;
    public AITackleState tackleState;
    public AIAttackState attackState;
    public AIShootState shootState;
    private float r; 
    
    
    
    
    private Controls controller;
    public void Start()
    {
        controller = player.gameObject.GetComponent<Controls>();
        float r = 0;
    }
    public void FixedUpdate()
    {
        float xPos = ball.transform.position.x;

        if(xPos >= 12)
        {
            defendState.Run();
        }
        else if (xPos < 12 && xPos > 0)
        {
            tackleState.Run();
        }
        else if (xPos < 0 && xPos > -12)
        {
            attackState.Run();
        }
        else if (xPos <= -12)
        {
            shootState.Run();
        }

       

        Vector2 v = AIGlobalBehaviour.FindDirectionTo(ball, goal, 0.6f);
        ballArrow.GetComponent<ArrowRotator>().SetPosition(v.x, v.y);
        Vector2 p = AIGlobalBehaviour.FindDirectionTo(ball, player, -1);
        //goalArrow.GetComponent<ArrowRotator>().SetPosition(p.x, p.y);

        /*
        Vector2 goalRadian = AIGlobalBehaviour.GetRadians(ball, goal, 1);
        Vector2 playerRadian = AIGlobalBehaviour.GetRadians(ball, player, -1);

        /*
        float xPR = playerRadian.x * (1 - r);
        float xGR = goalRadian.x * r;
        float xR = xPR + xGR;

        float yPR = playerRadian.y * (1 - r);
        float yGR = goalRadian.y * r;
        float yR = yPR + yGR;*/


        r += 0.01f;
        if (r >= 1)
        {
            r = 0;
        }
        double goalAngle = AIGlobalBehaviour.GetAngle(ball, goal, 1);
        double playerAngle = AIGlobalBehaviour.GetAngle(ball, player, -1);

        float nAngle = (float)playerAngle * (1 - r) + (float)goalAngle * r;

        Vector2 des = AIGlobalBehaviour.GetRadians(nAngle);
        Vector2 coordinates = AIGlobalBehaviour.FindDirectionTo(ball, des);


        goalArrow.GetComponent<ArrowRotator>().SetPosition(coordinates.x, coordinates.y);




        //Vector2 newPosition = AIGlobalBehaviour.FindDirectionTo(ball, xR, yR);

       // goalArrow.GetComponent<ArrowRotator>().SetPosition(newPosition.x, newPosition.y);


       // debug.text = " busy: " + AIGlobalBehaviour.CheckIfBusy(player);


        /*
        /* Figuring the position of the ball and rotating the player in the right
         * direction.
         

       // Player Rotation
       
        float ballx = ball.transform.position.x - player.transform.position.x;
        float bally = ball.transform.position.y - player.transform.position.y;
        controller.playerRotator.Rotate(ballx, bally);

        // Movement


        ballArrow.GetComponent<ArrowRotator>().SetPosition(player.transform.position.x, player.transform.position.y);
        ballArrow.GetComponent<ArrowRotator>().Rotate(ballx, bally);


        // Goal arrow rotation
        float goalx = goal.transform.position.x - player.transform.position.x;
        float goaly = goal.transform.position.y - player.transform.position.y;
        goalArrow.GetComponent<ArrowRotator>().SetPosition(ball.transform.position.x, ball.transform.position.y);
        goalArrow.GetComponent<ArrowRotator>().Rotate(goalx, goaly);
        double goalArrowRadians = goalArrow.transform.eulerAngles.z * Mathf.PI / 180;
        float goalArrowx = Mathf.Cos((float)goalArrowRadians);
        float goalArrowy = Mathf.Sin((float)goalArrowRadians);

        double radians = player.transform.eulerAngles.z * Mathf.PI / 180;
        float x = Mathf.Cos((float)radians);
        float y = Mathf.Sin((float)radians);



        controller.playerController.MovePlayer((x - goalArrowx), (y - goalArrowy));

        debug.text = "goal: (" + goalArrowx + ", " + goalArrowy + "), player: (" + x + ", " + y + ")";
        // Goalkeeper
        //controller.playerController.MovePlayer((x - goalArrowx), (y-goalArrowy));
        */

    }
    public void Shoot()
    {
        controller.weapon.Shoot();
    }
    public void MoveForward()
    {

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
        return goal;
    }
}
