using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AIMovementBehaviour 
{
    public static void LookAt(GameObject player, GameObject o)
    {
        /* This method makes the player look at the object. 
         * This is usually used to make the player look at the ball. 
         */
        float x = o.transform.position.x - player.transform.position.x;
        float y = o.transform.position.y - player.transform.position.y;
        AIBasicBehaviour.GetController(player).playerRotator.Rotate(x, y);
    }
    public static void LookAt(GameObject player, float x, float y)
    {
        AIBasicBehaviour.GetController(player).playerRotator.Rotate(x - player.transform.position.x, y - player.transform.position.y);
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
        AIBasicBehaviour.GetController(player).playerController.MovePlayer(x, y);

    }
    public static void MoveForward(GameObject player, float x, float y)
    {
        AIBasicBehaviour.GetController(player).playerController.MovePlayer(x, y);
    }
    public static void MoveBackward(GameObject player)
    {
        // Works the same as above but x and y are flipped
        double radians = player.transform.eulerAngles.z * Mathf.PI / 180;
        float x = Mathf.Cos((float)radians);
        float y = Mathf.Sin((float)radians);
        AIBasicBehaviour.GetController(player).playerController.MovePlayer(-x, -y);
    }
    public static void MoveUp(GameObject player)
    {
        double radians = player.transform.eulerAngles.z * Mathf.PI / 180;
        float x = Mathf.Cos((float)radians);
        float y = Mathf.Sin((float)radians);
        AIBasicBehaviour.GetController(player).playerController.MovePlayer(x * 0.5f, y);
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
    public static bool MoveTo(GameObject player, float x, float y)
    {
        // if the player is at the given position, return true

        // if the player is still moving return false
        return false;
    }
    public static void GetAPickup(GameObject player)
    {
        /* Locate closest pickup
         * Move to its position 
         */
    }
}
