using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AIGlobalBehaviour
{
    /*
     * A proxy for the Control script but this class is able to use
     * any player game object. 
     */
    private static float r = 0;
    public static Controls GetController(GameObject player)
    {
        return player.GetComponent<Controls>();
    }
    public static bool CheckIfBusy(GameObject player)
    {
        return player.GetComponent<PlayerController>().busyState.GetState();
    }
    public static void UseShield(GameObject player)
    {
        GetController(player).UseShield();
    }
    public static void UseSword(GameObject player)
    {
        
        PlayerController playerController = player.GetComponent<PlayerController>();
        
        GetController(player).UseSword();
        

    }
    public static void UseGun(GameObject player)
    {
        GetController(player).Shoot();
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
    public static void MoveUp(GameObject player)
    {
        double radians = player.transform.eulerAngles.z * Mathf.PI / 180;
        float x = Mathf.Cos((float)radians);
        float y = Mathf.Sin((float)radians);
        GetController(player).playerController.MovePlayer(x * 0.5f, y);
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
    public static void PositionInFrontOf(GameObject player, GameObject ball, GameObject goal)
    {

        Vector2 goalDirection = FindDirectionTo(ball, goal, 0.5f);
        Vector2 playerDirection = FindDirectionTo(ball, player, 0.5f);

        

        Vector2 coordinates = AvoidTheBall(player, ball, goal, r);


        if (CalculateLengthBetween(player, coordinates.x, coordinates.y) > 1)
        {
            r = 0;
            LookAt(player, coordinates.x, coordinates.y);
            MoveForward(player);
        } else
        {
            r += 0.3f;
            Vector2 c = AvoidTheBall(player, ball, goal, r);
            LookAt(player, c.x, c.y);
            MoveForward(player);
        }
        
    }
    public static Vector2 AvoidTheBall(GameObject player, GameObject ball, GameObject goal, float r)
    {
        double goalAngle = GetAngle(ball, goal, 1);
        double playerAngle = GetAngle(ball, player, -1);

        float nAngle = (float)playerAngle * (1 - r) + (float)goalAngle * r;

        Vector2 des = GetRadians(nAngle);
        return FindDirectionTo(ball, des);
    }
    public static void PushBall(GameObject player, GameObject ball, GameObject goal)
    {

        Vector2 goalDirection = FindDirectionTo(ball, goal, 1);
        
        if (CalculateLengthBetween(player, goalDirection.x, goalDirection.y) < 0.2)
        {
           LookAt(player, goal);
           MoveForward(player);
            //PositionInFrontOf(player, ball, goal);
        }
        else
        {
            PositionInFrontOf(player, ball, goal);
        }
    }
    public static void ShootAtGoal(GameObject player, GameObject ball, GameObject goal)
    {

        Vector2 goalDirection = FindDirectionTo(ball, goal, 0.6f);

        //PushBall(player, ball, goal);
        if (CalculateLengthBetween(player, goalDirection.x, goalDirection.y) < 0.4)
        {
            //LookAt(player, goal);
            UseSword(player);
        }
        PositionInFrontOf(player, ball, goal);
    }

    
    public static Vector2 FindDirectionTo(GameObject ball, GameObject goal, float offset)
    {
        /* This method calculates the position of the direction to the goal. 
         */
         

        Vector2 radians = GetRadians(ball, goal, offset);
        float x2 = radians.x;
        float y2 = radians.y;

        float ballArrowx = ball.transform.position.x - y2;
        float ballArrowy = ball.transform.position.y - x2;

        return new Vector2(ballArrowx, ballArrowy);

    }
    public static Vector2 FindDirectionTo(GameObject ball, Vector2 angle)
    {
        float x2 = angle.x;
        float y2 = angle.y;

        float ballArrowx = ball.transform.position.x - y2;
        float ballArrowy = ball.transform.position.y - x2;

        return new Vector2(ballArrowx, ballArrowy);
    }


    public static Vector2 GetRadians(GameObject source, GameObject destination, float offset)
    {
        /* This method returns radians in the wanted direction. 
         * It basically converts angles to a Vector. 
         */
        double angle = GetAngle(source, destination, offset);
        
        float x2 = Mathf.Cos((float)angle) * offset;
        float y2 = Mathf.Sin((float)angle) * offset;

        return new Vector2(x2, y2);
    }

   
    public static double GetAngle(GameObject source, GameObject destination, float offset)
    {
        float ballx = destination.transform.position.x - source.transform.position.x;
        float bally = destination.transform.position.y - source.transform.position.y;
        float angle = Mathf.Atan2(ballx * offset, bally * offset) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        double radians2 = rotation.eulerAngles.z * Mathf.PI / 180;
        return radians2; 

    }





    public static Vector2 FindDirectionTo(GameObject source, float x, float y)
    {
        /* This method calculates the position of the direction to the goal. 
         * 
         */

        float ballArrowx = source.transform.position.x - y;
        float ballArrowy = source.transform.position.y - x;

        return new Vector2(ballArrowx, ballArrowy);

    }

    public static Vector2 GetRadians(double angle)
    {
        
        float x2 = Mathf.Cos((float)angle);
        float y2 = Mathf.Sin((float)angle);

        return new Vector2(x2, y2);
    }



}
