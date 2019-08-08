using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AILineOfSight : MonoBehaviour
{
    /* This class takes care of the line of sight which is achieved by 
     * drawing a line from the player to the goal. It uses the Physics2D.Linecast
     * method which casts an invisible line that returns a boolean value. 
     */

    public AIController aiController;
    public Transform goalSightEnd;
    public GameObject dummy;
    private Transform playerSightStart, playerSightEnd;

    public bool playerSpotted = false,
        wallSpottedMiddle = false,
        wallSpottedTop = false,
        wallSpottedBottom = false,
        playerSpottedMiddle = false,
        playerSpottedTop = false,
        playerSpottedBottom = false,
        ballSpottedMiddle = false,
        ballSpottedTop = false,
        ballSpottedBottom = false;

    private Vector2 goalTop, goalBottom, goalMiddle;

    public void Start()
    {

        if (aiController.GetOppositeGoal().transform.position.x > 0)
        {
            goalSightEnd.position = new Vector2(-goalSightEnd.position.x, 0);
        }
        /* The AI can shoot at three positions of the goal - top, middle and bottom. 
         * More could be added for more precision however, in a 1vs1 game it is very
         * unlikely that the opponent will be in the way of all three positions
         * at the same time.
         */
        playerSightStart = aiController.player.GetComponent<LineOfSight>().playerSightStart;
        playerSightEnd = aiController.player.GetComponent<LineOfSight>().playerSightEnd;
        goalMiddle = new Vector2(goalSightEnd.position.x, goalSightEnd.position.y);
        goalTop = new Vector2(goalSightEnd.position.x, goalSightEnd.position.y + 2.5f);
        goalBottom = new Vector2(goalSightEnd.position.x, goalSightEnd.position.y - 2.5f);
        dummy.transform.position = goalMiddle;

    }
    void Update()
    {
        Raycasting();
    }
    void Raycasting()
    {
        /* This method draws an imaginary line between two points and changes
         * the boolean values based on the outcome. 
         */
        playerSpotted = Physics2D.Linecast(playerSightStart.position, playerSightEnd.position, 1 << LayerMask.NameToLayer("Player"));

        // Middle
        wallSpottedMiddle = Physics2D.Linecast(playerSightStart.position, goalMiddle, 1 << LayerMask.NameToLayer("Wall"));
        playerSpottedMiddle =  Physics2D.Linecast(playerSightStart.position, goalMiddle, 1 << LayerMask.NameToLayer("Player"));
        ballSpottedMiddle = Physics2D.Linecast(playerSightStart.position, goalMiddle, 1 << LayerMask.NameToLayer("Ball"));

        // Top
        wallSpottedTop = Physics2D.Linecast(playerSightStart.position, goalTop, 1 << LayerMask.NameToLayer("Wall"));
        playerSpottedTop = Physics2D.Linecast(playerSightStart.position, goalTop, 1 << LayerMask.NameToLayer("Player"));
        ballSpottedTop = Physics2D.Linecast(playerSightStart.position, goalTop, 1 << LayerMask.NameToLayer("Ball"));

        // Bottom
        wallSpottedBottom = Physics2D.Linecast(playerSightStart.position, goalBottom, 1 << LayerMask.NameToLayer("Wall"));
        playerSpottedBottom = Physics2D.Linecast(playerSightStart.position, goalBottom, 1 << LayerMask.NameToLayer("Player"));
        ballSpottedBottom = Physics2D.Linecast(playerSightStart.position, goalBottom, 1 << LayerMask.NameToLayer("Ball"));


        GetAvailablePoint();

        // Debug
        Debug.DrawLine(playerSightStart.position, playerSightEnd.position, Color.blue);
        Debug.DrawLine(playerSightStart.position, goalMiddle, Color.green);
        Debug.DrawLine(playerSightStart.position, goalTop, Color.green);
        Debug.DrawLine(playerSightStart.position, goalBottom, Color.green);

    }
    public bool CheckIfPlayerSpotted()
    {
        return this.playerSpotted;
    }
    public bool CheckIfWallSpotted()
    {
        bool ret = wallSpottedMiddle || wallSpottedBottom || wallSpottedTop;
        return ret;
    }
    public bool CheckIfBallSpotted()
    {
        bool ret = ballSpottedBottom || ballSpottedMiddle || ballSpottedTop;
        return ret;
    }
   
    public GameObject GetAvailablePoint()
    {   
        /* Check if there is a player or a wall in the way of the casted line. 
         * If there is, change the position of the available point and then return it.
         */
        if (!wallSpottedMiddle && !playerSpottedMiddle)
        {
            dummy.transform.position = goalMiddle;
        }
        else if (!wallSpottedTop && !playerSpottedTop)
        {
            dummy.transform.position = goalTop;
        }
        else if (!wallSpottedBottom && !playerSpottedBottom)
        {
            dummy.transform.position = goalBottom;
        }
        return dummy;
    }
    
}
