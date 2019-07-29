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
    public static float GetR()
    {
        return r;
    }
    

    
    public static void PositionInFrontOf(GameObject player, GameObject ball, GameObject goal)
    {
        r += 0.01f;
        if (r >= 1)
        {
            r = 0;
        }
        /*

         Vector2 gPos = AvoidTheBall(player, ball, goal, 1);
         LookAt(player, gPos.x, gPos.y);

         double goalAngle = GetAngle(ball, goal, 1);
         double playerAngle = GetAngle(ball, player, -1);

         float nAngle = (float)playerAngle * (1 - r) + (float)goalAngle * r;

         Vector2 des = GetRadians(nAngle, 1.3f);
         Vector2 coordinates = AIGlobalBehaviour.FindDirectionTo(ball, des);



         double a = GetAngle(player, coordinates.y, coordinates.x);
         Vector2 d = GetRadians(a);
         MoveForward(player, d.y, d.x);

         //float ballx = gPos.x - player.transform.position.x;
         //float bally = gPos.y - player.transform.position.y;
         //float angle = Mathf.Atan2(gPos.x, gPos.y) * Mathf.Rad2Deg;
         // Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

         // MoveForward

         // double radians = rotation.eulerAngles.z * Mathf.PI / 180;
         //  float x = Mathf.Cos((float)radians);
         //  float y = Mathf.Sin((float)radians);



         // MoveForward(player, x, y);
         /*

         if (CalculateLengthBetween(player, coordinates.x, coordinates.y) > 1)
         {
             r = 0;
             LookAt(player, ball);
             MoveForward(player);
         } else
         {
             r += 0.3f;


         }*/

    }
    public static Vector2 AvoidTheBall(GameObject player, GameObject ball, GameObject goal, float r)
    {
        double goalAngle = GetAngle(ball, goal, 1);
        double playerAngle = GetAngle(ball, player, -1);

        float nAngle = (float)playerAngle * (1 - r) + (float)goalAngle * r;

        Vector2 des = GetRadians(nAngle, 2 - (r * 1.2f));
        return FindDirectionTo(ball, des);
    }
    

    
    public static void PushBall(GameObject player, GameObject ball, GameObject goal)
    {

        //Vector2 goalDirection = FindDirectionTo(ball, goal, 1);
        
       // if (CalculateLengthBetween(player, goalDirection.x, goalDirection.y) < 0.4f)
     //   {
           //LookAt(player, goal);
      //     MoveForward(player);
            //PositionInFrontOf(player, ball, goal);
     //   }
     //   else
   //     {
            PositionInFrontOf(player, ball, goal);
      //  }
    }
    public static void ShootAtGoal(GameObject player, GameObject ball, GameObject goal)
    {

        Vector2 goalDirection = FindDirectionTo(ball, goal, 0.6f);

        //PushBall(player, ball, goal);
    //    if (CalculateLengthBetween(player, goalDirection.x, goalDirection.y) < 0.4)
    //    {
            //LookAt(player, goal);
     //       UseSword(player);
   //     }
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


    public static Vector2 GetRadians(GameObject source, GameObject destination, float offset, float size = 1)
    {
        /* This method returns radians in the wanted direction. 
         * It basically converts angles to a Vector. 
         */
        double angle = GetAngle(source, destination, offset);
        
        float x2 = Mathf.Cos((float)angle) * offset;
        float y2 = Mathf.Sin((float)angle) * offset;

        return new Vector2(x2 * size, y2 * size);
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
    public static double GetAngle(GameObject source, float x, float y, float offset = 1)
    {
        float ballx = x - source.transform.position.x;
        float bally = y - source.transform.position.y;
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

    public static Vector2 GetRadians(double angle, float size = 1)
    {
        
        float x = Mathf.Cos((float)angle);
        float y = Mathf.Sin((float)angle);

        return new Vector2(x * size, y * size);
    }



}
