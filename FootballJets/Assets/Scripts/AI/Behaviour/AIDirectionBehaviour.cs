using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AIDirectionBehaviour 
{
    public static double GetRadian(GameObject source, float x, float y, float offset = 1)
    {
        /* It is the first part in converting an angle from source object to another
        * object to an actual position around the source object.
        * This method calculates the angle from the source object to the destination
        * by first finding the position of the destination in regards of the source, 
        * then converting it to an angle. Once the angle is found, it is converted 
        * to a Quaternion from which a radian is extracted by using the euler angles. 
        * This method should only be used in GetVectors method. */
        float destinationx = x - source.transform.position.x;
        float destinationy = y - source.transform.position.y;
        float angle = Mathf.Atan2(destinationx * offset, destinationy * offset) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        double radians2 = rotation.eulerAngles.z * Mathf.PI / 180;
        return radians2;
    }
    public static double GetRadian(GameObject source, GameObject destination, float offset)
    {
        
        float destinationx = destination.transform.position.x;
        float destinationy = destination.transform.position.y;
       
        return GetRadian(source, destinationx, destinationy, offset);
    }
    
    public static Vector2 GetDirectionVector(GameObject source, GameObject destination, float offset, float size = 1)
    {
        /* This method is the second part in the three part methods which
         * converts a radian to actual position.
         * This method returns a vector in the wanted direction. It is used with
         * the GetRadian method to get the exact vector in which position to move.  */
        double radian = GetRadian(source, destination, offset);

        float x2 = Mathf.Cos((float)radian) * offset;
        float y2 = Mathf.Sin((float)radian) * offset;

        return new Vector2(x2 * size, y2 * size);
    }
    public static Vector2 GetDirectionVector(double radian, float size = 1)
    {

        float x = Mathf.Cos((float)radian);
        float y = Mathf.Sin((float)radian);

        return new Vector2(x * size, y * size);
    }


    public static Vector2 FindPositionOf(GameObject source, GameObject destination, float offset)
    {
        /* This method is a reversed version of the FindDirectionVector method. 
         * It finds a direction vector towards a wanted object (destination) and
         * then finds the x and y coordinates of that direction vector.
         * It is used when guiding the AI to avoid the ball. 
         */
        Vector2 directionVector = GetDirectionVector(source, destination, offset);
        float x2 = directionVector.x;
        float y2 = directionVector.y;

        float sourcex = source.transform.position.x - y2;
        float sourcey = source.transform.position.y - x2;

        return new Vector2(sourcex, sourcey);

    }
    public static Vector2 FindPositionOf(GameObject source, Vector2 directionVector)
    {
        float x2 = directionVector.x;
        float y2 = directionVector.y;

        float sourcex = source.transform.position.x - y2;
        float sourcey = source.transform.position.y - x2;

        return new Vector2(sourcex, sourcey);
    }
    public static Vector2 FindPositionOf(GameObject source, float x, float y)
    {
        

        float posx = source.transform.position.x - y;
        float posy = source.transform.position.y - x;

        return new Vector2(posx, posy);

    }
    public static Vector2 GetRotationVector(GameObject player)
    {
        /* This method is used to find the direction vector of the player's rotation. 
         */
        double radians = player.transform.eulerAngles.z * Mathf.PI / 180;
        float x = Mathf.Cos((float)radians);
        float y = Mathf.Sin((float)radians);
        return new Vector2(x, y);
    }
    
    
}
