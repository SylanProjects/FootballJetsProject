using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIControl : MonoBehaviour
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
    private Controls controller;
    public void Start()
    {
        controller = player.gameObject.GetComponent<Controls>();
    }
    public void FixedUpdate()
    {
        /* Figuring the position of the ball and rotating the player in the right
         * direction.
         */

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

    }
    public void Shoot()
    {
        controller.weapon.Shoot();
    }
}
