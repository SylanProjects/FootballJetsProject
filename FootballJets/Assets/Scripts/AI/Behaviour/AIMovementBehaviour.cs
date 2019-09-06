using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AIMovementBehaviour 
{
    public static void LookAt(GameObject player, GameObject o)
    {
        /* This method makes the player look at the object. 
         * This is usually used to make the player look at the ball. 
         * First, the position of the object we want to look at, in regards of the player
         * is found and then the player is rotated. 
         */
        float x = o.transform.position.x - player.transform.position.x;
        float y = o.transform.position.y - player.transform.position.y;
        AIBasicBehaviour.GetController(player).playerRotator.Rotate(x, y);
    }
    public static void LookAt(GameObject player, float x, float y)
    {
        AIBasicBehaviour.GetController(player).playerRotator.Rotate(x - player.transform.position.x, y - player.transform.position.y);
    }
    public static void LookAt(GameObject player, Vector2 vector)
    {
        LookAt(player, vector.x, vector.y);
    }
    public static void MoveForward(GameObject player)
    {
        /* This method moves player forward but it does not
         * take care of the direction. To make the player run to the ball
         * use RunToTheBall method.
         */
        
        Vector2 dir = AIDirectionBehaviour.GetRotationVector(player);
        AIBasicBehaviour.GetController(player).playerController.playerMovement.MovePlayer(dir.x, dir.y);

    }
    public static void MoveForward(GameObject player, float x, float y)
    {
        /* x and y are not the position of the object but the vector towards it. 
        */
        AIBasicBehaviour.GetController(player).playerController.playerMovement.MovePlayer(x, y);
    }
    public static void MoveBackward(GameObject player)
    {
        // Works the same as above but x and y are flipped
        Vector2 dir = AIDirectionBehaviour.GetRotationVector(player);
        AIBasicBehaviour.GetController(player).playerController.playerMovement.MovePlayer(-dir.x, -dir.y);
    }
   
    public static void RunToTheBall(GameObject player, GameObject ball)
    {
        /* This method requires the player character to look at the ball first. 
         */
        MoveTowards(player, ball.transform.position.x, ball.transform.position.y);

    }
    public static void RunAwayFromBall(GameObject player, GameObject ball)
    {
        MoveTowards(player, ball.transform.position.x, ball.transform.position.y);
    }
    public static void MoveTowards(GameObject player, float x, float y)
    {
        /* First the angle from the player to the given position needs to be found
         * since the player does not necessarily has to look in the direction
         * that it is moving. 
         */
        double a = AIDirectionBehaviour.GetRadian(player, x, y);
        Vector2 d = AIDirectionBehaviour.GetDirectionVector(a);
        MoveForward(player, d.y, d.x);
    }
    public static void MoveTowards(GameObject player, GameObject destination)
    {
        float x = destination.transform.position.x;
        float y = destination.transform.position.y;
        MoveTowards(player, x, y);
    }
    
}
