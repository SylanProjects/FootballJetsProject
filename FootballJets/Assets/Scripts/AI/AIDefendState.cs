using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AIDefendState : AIState
{

    public Text debug;
    public new void Run()
    {


        //AIGlobalBehaviour.LookAt(player, ball);
        //AIGlobalBehaviour.MoveForward(player);

        AIGlobalBehaviour.PushBall(player, ball);
        
       

        debug.text = "Defend State" + stateController.name;
        /* if the ball is not in between this player and the opposite goal
         * position in front of the goal to block the other player from scoring a goal
         * 
         * if this player is not close to a goal and the ball is in front of the goal, 
         * and if shooting the ball would not cause it to score a goal for the opposite team, shoot it
         * 
         * if the ball is close to the player, use sword to kick it away
         * if the ball is further away, shoot it
         * 
         * if the ball is on the side and there is a pickup available close, pick it up
         * the lower the health / stamina points - the more likely it is for this player get a pickup
         * 
         * shoot the player of opposite if he has a low hp and this player is blocking the goal
         * 
         * use shield to block the goal 
         * 
         * if the ball is approaching (check velocity etc.) use shield to block it 
         * 
         */
    }
    private void BlockTheGoal()
    {

    }
    
}
