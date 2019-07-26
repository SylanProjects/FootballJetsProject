using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AIGlobalBehaviour
{
    /*
     * A proxy for the Control script but this class is able to use
     * any player game object. 
     */
    public static Controls GetController(GameObject player)
    {
        return player.GetComponent<Controls>();
    }
    public static void UseShield(GameObject player)
    {
        GetController(player).UseShield();
    }
    public static void UseSword(GameObject player)
    {
        player.GetComponent<Controls>().UseSword();
    }
    public static void UseGun(GameObject player)
    {
        player.GetComponent<Controls>().Shoot();
    }
    public static void Reload(GameObject player)
    {
        player.GetComponent<Controls>().Reload();
    }
    public static void Sprint(GameObject player)
    {
        // change the value of sprint to 1
    }
    public static void SetGun(GameObject player, string gunName)
    {
        player.GetComponent<Controls>().SetGun(gunName);
    }
    public static void NextGun(GameObject player)
    {
        player.GetComponent<Controls>().NextGun();
    }
    public static void PassToATeamMate(GameObject player, string teamMate)
    {
        // look at a teammate
        // move to the ball
        // kick the ball
    }
    public static void GetAPickup(GameObject player)
    {
        /* Locate closest pickup
         * Move to its position 
         */
    }
    public static void LookAt(GameObject player, GameObject o)
    {
        /* This method makes the player look at the object. 
         * This is usually used to make the player look at the ball. 
         */
        float x = o.transform.position.x - player.transform.position.x;
        float y = o.transform.position.y - player.transform.position.y;
        GetController(player).playerRotator.Rotate(x, y);
    }
    public static void LookAt(GameObject player, float x, float y)
    {
        GetController(player).playerRotator.Rotate(x - player.transform.position.x, y - player.transform.position.y);
    }
    public static void MoveForward(GameObject player)
    {
        /* This method moves player forward but it does not
         * take care of the direction. To make the player run to the ball
         * use RunToTheBall method.
         */
        double radians = player.transform.eulerAngles.z * Mathf.PI / 180;
        float x = Mathf.Cos((float)radians);
        float y = Mathf.Sin((float)radians);
        GetController(player).playerController.MovePlayer(x, y);

    }
    public static void MoveBackward(GameObject player)
    {
        // Works the same as above but x and y are flipped
        double radians = player.transform.eulerAngles.z * Mathf.PI / 180;
        float x = Mathf.Cos((float)radians);
        float y = Mathf.Sin((float)radians);
        GetController(player).playerController.MovePlayer(-x, -y);
    }
    public static void RunToTheBall(GameObject player, GameObject ball)
    {
        LookAt(player, ball);
        MoveForward(player);
        
    }
    public static void RunAwayFromBall(GameObject player, GameObject ball)
    {
        LookAt(player, ball);
        MoveBackward(player);
    }
    public static float CalculateLengthBetween(GameObject o1, GameObject o2)
    {
        /*This method calculates the length between two objects.
         */
        float x1 = o1.transform.position.x;
        float y1 = o1.transform.position.y;
        float x2 = o2.transform.position.x;
        float y2 = o2.transform.position.y;

        return Mathf.Sqrt((  Mathf.Pow((x2 - x1), 2)  +  Mathf.Pow((y2 - y1), 2)  ));
    }
    public static float CalculateLengthBetween(GameObject o1, float x2, float y2)
    {
        /*This method calculates the length between an object and a point.
         */
        float x1 = o1.transform.position.x;
        float y1 = o1.transform.position.y;

        return Mathf.Sqrt((Mathf.Pow((x2 - x1), 2) + Mathf.Pow((y2 - y1), 2)));
    }
    public static float CalculateLengthBetween(float x1, float y1, float x2, float y2)
    {
        /*This method calculates the length between two points.
         */
        return Mathf.Sqrt((Mathf.Pow((x2 - x1), 2) + Mathf.Pow((y2 - y1), 2)));
    }

    public static bool MoveTo(GameObject player, float x, float y)
    {
        // if the player is at the given position, return true

        // if the player is still moving return false
        return false;
    }
    public static void PositionInFrontOf(GameObject player, GameObject ball)
    {
        // Look behind the ball
        //float bx = ball.transform.position.x + (ball.transform.position.x / 24); // distance between 0 and x position
        //float by = ball.transform.position.y + (ball.transform.position.y / 12);
        //LookAt(player, bx, by);
        //MoveForward(player);


        if(CalculateLengthBetween(player, ball) > 2)
        {
            RunToTheBall(player, ball);
        }
        if (CalculateLengthBetween(player, ball) < 2)
        {
            RunAwayFromBall(player, ball);
        }
        
        
    }
    public static void PushBall(GameObject player, GameObject ball)
    {

        PositionInFrontOf(player, ball);
        // If the position of the x of the ball is higher than players, move right


        /*
        RunToTheBall(player, ball);
        if (CalculateLengthBetween(player, ball) < 2)
        {
            PositionInFrontOf(player, ball);
        }*/
        
    }
}
