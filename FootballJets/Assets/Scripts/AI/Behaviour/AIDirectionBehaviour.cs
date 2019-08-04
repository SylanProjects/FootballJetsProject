using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AIDirectionBehaviour 
{
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
    public static Vector2 GetRadians(double angle, float size = 1)
    {

        float x = Mathf.Cos((float)angle);
        float y = Mathf.Sin((float)angle);

        return new Vector2(x * size, y * size);
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



    public static Vector2 FindPositionOf(GameObject source, float x, float y)
    {
        /* This method calculates the position of the direction to the goal. 
         * Converts radians to position.
         */

        float posx = source.transform.position.x - y;
        float posy = source.transform.position.y - x;

        return new Vector2(posx, posy);

    }
    public static Vector2 FindPositionOf(GameObject ball, Vector2 angle)
    {
        float x2 = angle.x;
        float y2 = angle.y;

        float ballArrowx = ball.transform.position.x - y2;
        float ballArrowy = ball.transform.position.y - x2;

        return new Vector2(ballArrowx, ballArrowy);
    }
    public static Vector2 FindPositionOf(GameObject ball, GameObject goal, float offset)
    {


        Vector2 radians = GetRadians(ball, goal, offset);
        float x2 = radians.x;
        float y2 = radians.y;

        float ballArrowx = ball.transform.position.x - y2;
        float ballArrowy = ball.transform.position.y - x2;

        return new Vector2(ballArrowx, ballArrowy);

    }
}
