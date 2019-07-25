using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AIGlobalBehaviour
{
    /*
     * A proxy for the Control script but this class is able to use
     * any player game object. 
     */

    public static void UseShield(GameObject player)
    {
        player.GetComponent<Controls>().UseShield();
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
    public static void RunToABall(GameObject player)
    {

    }
    public static bool MoveTo(GameObject player, float x, float y)
    {
        // if the player is at the given position, return true

        // if the player is still moving return false
        return false;
    }
    public static void PositionInFrontOfABall(GameObject player)
    {
        
    }
}
