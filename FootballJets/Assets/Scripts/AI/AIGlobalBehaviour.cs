using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIGlobalBehaviour
{
    /*
     * A proxy for the Control script but this class is able to use
     * any player game object. 
     */

    public void UseShield(GameObject player)
    {
        player.GetComponent<Controls>().UseShield();
    }
    public void UseSword(GameObject player)
    {
        player.GetComponent<Controls>().UseSword();
    }
    public void UseGun(GameObject player)
    {
        player.GetComponent<Controls>().Shoot();
    }
    public void Reload(GameObject player)
    {
        player.GetComponent<Controls>().Reload();
    }
    public void Sprint(GameObject player)
    {
        // change the value of sprint to 1
    }
    public void SetGun(GameObject player, string gunName)
    {
        player.GetComponent<Controls>().SetGun(gunName);
    }
    public void NextGun(GameObject player)
    {
        player.GetComponent<Controls>().NextGun();
    }
    public void PassToATeamMate(GameObject player, string teamMate)
    {
        // look at a teammate
        // move to the ball
        // kick the ball
    }
    public void GetAPickup(GameObject player)
    {
        /* Locate closest pickup
         * Move to its position 
         */
    }
    public void RunToABall(GameObject player)
    {

    }
    public bool MoveTo(GameObject player, float x, float y)
    {
        // if the player is at the given position, return true

        // if the player is still moving return false
        return false;
    }
    public void PositionInFrontOfABall(GameObject player)
    {
        
    }
}
