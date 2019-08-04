using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AILineOfSight : MonoBehaviour
{
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
        playerSpottedBottom = false;

    private Vector2 goalTop, goalBottom, goalMiddle;

    public void Start()
    {
        if (aiController.GetOppositeGoal().transform.position.x > 0)
        {
            goalSightEnd.position = new Vector2(-goalSightEnd.position.x, 0);
        }
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
        playerSpotted = Physics2D.Linecast(playerSightStart.position, playerSightEnd.position, 1 << LayerMask.NameToLayer("Player"));


        Debug.DrawLine(playerSightStart.position, goalMiddle, Color.green);
        // Middle
        wallSpottedMiddle = Physics2D.Linecast(playerSightStart.position, goalMiddle, 1 << LayerMask.NameToLayer("Wall"));
        playerSpottedMiddle =  Physics2D.Linecast(playerSightStart.position, goalMiddle, 1 << LayerMask.NameToLayer("Player"));
        // Top
        Debug.DrawLine(playerSightStart.position, goalTop, Color.green);
        wallSpottedTop = Physics2D.Linecast(playerSightStart.position, goalTop, 1 << LayerMask.NameToLayer("Wall"));
        playerSpottedTop = Physics2D.Linecast(playerSightStart.position, goalTop, 1 << LayerMask.NameToLayer("Player"));
        // Bottom
        Debug.DrawLine(playerSightStart.position, goalBottom, Color.green);
        wallSpottedBottom = Physics2D.Linecast(playerSightStart.position, goalBottom, 1 << LayerMask.NameToLayer("Wall"));
        playerSpottedBottom = Physics2D.Linecast(playerSightStart.position, goalBottom, 1 << LayerMask.NameToLayer("Player"));
        Debug.DrawLine(playerSightStart.position, playerSightEnd.position, Color.blue);

        GetAvailablePoint();

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
    public bool CheckIfReady()
    {
        bool ret = wallSpottedMiddle || wallSpottedBottom || wallSpottedTop;
        return ret;
    }
    public GameObject GetAvailablePoint()
    {
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
