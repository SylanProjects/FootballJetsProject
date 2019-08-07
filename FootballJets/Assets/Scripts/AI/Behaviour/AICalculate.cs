using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICalculate
{

    public static float CalculateLengthBetween(GameObject o1, GameObject o2)
    {
        /*This method calculates the length between two objects.
         */
        float x1 = o1.transform.position.x;
        float y1 = o1.transform.position.y;
        float x2 = o2.transform.position.x;
        float y2 = o2.transform.position.y;

        return Mathf.Sqrt((Mathf.Pow((x2 - x1), 2) + Mathf.Pow((y2 - y1), 2)));
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
    public static Vector2 FindPointBetween(GameObject player, GameObject ball, GameObject goal)
    {
        /* First find the angle from the ball to the player (playerAngle), 
         * and from the ball to the goal (goalAngle).
         * These points are used to guide the player around the ball thus, a counter
         * value is needed, in this case r that goes from 0 to 1. 
         * The position of the point in which the player should move will keep circling
         * the ball. Imagine an arrow a few pixels away from the ball, playerAngle would make it
         * point in the direction of the player, and goalAngle would make it point
         * to the goal (we want to move player to the other side of that point so the ball is 
         * between the player and the goal).
         */

        float ar = player.GetComponent<Counter>().a;
        double goalAngle = AIDirectionBehaviour.GetRadian(ball, goal, 1);
        double playerAngle = AIDirectionBehaviour.GetRadian(ball, player, -1);

        /* To make sure that if the player (AI) is "under" the ball, it does not circle
         * the whole ball to get to the goalAngle position, this part was needed.
         * Since the bottom (0, -1) of the ball is 0 going to the left or 6.3 going to the right
         * i.e. the point where the angle resets, 6.3 is added to move that point to the left 
         * side of the ball. 
         */

        Vector2 playerDes = AIDirectionBehaviour.GetDirectionVector(playerAngle);
        Vector2 playerPos = AIDirectionBehaviour.FindPositionOf(ball, playerDes);
        if (playerPos.x > player.transform.position.x && playerPos.y > player.transform.position.y)
        {
            playerAngle += 6.3;
        }
        float nAngle = (float)playerAngle * (1 - ar) + (float)goalAngle * ar;
        Vector2 des = AIDirectionBehaviour.GetDirectionVector(nAngle, 1.2f);
        Vector2 pos = AIDirectionBehaviour.FindPositionOf(ball, des);

        return new Vector2(pos.x, pos.y);

    }

    public static Vector2 AvoidTheBall(GameObject player, GameObject ball, GameObject goal, float r)
    {
        // Probably useless
        /* First the angle from the ball to the goal and from the ball to the player is 
         * needed. The GetAngle method returns a double with the direction.
         * Next a new angle is found which is a point between the goalAngle and
         * the playerAngle depending on the position of r. r is a float value that keeps going
         * from 0 to 1. Constantly updating these values makes the nAngle position to change
         * and circle around the ball between the goalAngle and the playerAngle. 
         * Lastly the double is converted to radians and then the actual position
         * is found by using the FindPositionOf method.
         */
        double goalAngle = AIDirectionBehaviour.GetRadian(ball, goal, 1);
        double playerAngle = AIDirectionBehaviour.GetRadian(ball, player, -1);

        float nAngle = (float)playerAngle * (1 - r) + (float)goalAngle * r;

        Vector2 des = AIDirectionBehaviour.GetDirectionVector(nAngle, 2 - (r));
        return AIDirectionBehaviour.FindPositionOf(ball, des);
    }
}
