using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIShootState : AIState
{
    public Text debug;
    
    public new void Run()
    {
        debug.text = "Shoot State" + stateController.name;
        
        if (aIController.lineOfSight.CheckIfWallSpotted())
        {
            
            AIGlobalBehaviour.ShootInTheMiddle(player, ball, goal);
        }
        else
        {
            AIGlobalBehaviour.ShootAtGoal(player, ball, aIController.lineOfSight.GetAvailablePoint());
        }
        
        /* If the ball is in the corner, move it in the middle so a shot can be taken 
         * easily. First calculate the point where the ball cannot
         * be shot at the goal, and then push it back to the middle. 
         * If the ball is ready, shoot it at the goal. 
         * 
         */

    }
}
