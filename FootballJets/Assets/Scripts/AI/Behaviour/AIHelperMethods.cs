using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AIHelperMethods
{
    public static void ChooseRunMethod(AIState state, int position)
    {
        /* This method chooses the right method based on the position of the players.
         */
        switch (position)
        {
            case 0:
                state.RunZeroPosition();
                break;
            case 1:
                state.RunOnePosition();
                break;
            case 2:
                state.RunTwoPosition();
                break;
            case 3:
                state.RunTwoPosition();
                break;
        }
        
    }
    public static int GetPositionStatus(GameObject aiPlayer, GameObject player, GameObject ball, GameObject goal)
    {
        /* 0, 1, 2 or 3
         * 0 is when the ball is between the opponents (player) goal and the AIPlayer and the player.
         * (opponent in this case is the player, which may or may not be another AIPlayer). 
         * This position is the most beneficial for the aiPlayer object because it
         * can be easier to shoot the ball at the goal.
         * 
         * 1 is when the ball is between the opponent and the AI but the aiPlayer is between the
         * opponent's goal and the ball. This means that the aiPlayer should not push the ball
         * towards its own goal. And it also means that the player is able to kick the ball towards
         * the goal. 
         * 
         * 2 is similar to 1 but this time it is reversed, aiPlayer is able to shoot the ball
         * at the goal but so is the player. This is a neutral position.
         * 
         * 3 the same as 0 but reversed so the ball is between the aiPlayer and the player, and the 
         * AI's goal, so player is able to shoot the ball at the goal, and the aiPlayer is
         * not able to defend it, it should move between its goal and the ball as fast
         * as possible. 
         */
        float aiXPosition = aiPlayer.transform.position.x;
        float playerXPosition = player.transform.position.x;
        float ballXPosition = ball.transform.position.x;
        float goalXPosition = goal.transform.position.x;

        bool goalIsOnTheLeft = goalXPosition < ballXPosition;
        bool aiIsOnTheLeftToBall = aiXPosition < ballXPosition;
        bool playerIsOnTheLeftToBall = playerXPosition < ballXPosition;
        bool aiIsOnTheLeftToPlayer = aiXPosition < playerXPosition;
        bool ballIsOnTheLeftToPlayerAndAI = !playerIsOnTheLeftToBall && !aiIsOnTheLeftToBall;
        bool ballIsOnTheRightToPlayerAndAI = playerIsOnTheLeftToBall && aiIsOnTheLeftToBall;

        bool zeroPosition = (goalIsOnTheLeft & ballIsOnTheLeftToPlayerAndAI) || (!goalIsOnTheLeft & ballIsOnTheRightToPlayerAndAI);

        if (zeroPosition)
        {
            return 0;
        }

        bool ballIsBetweenPlayerAndAI = (aiIsOnTheLeftToBall & !playerIsOnTheLeftToBall) || (!aiIsOnTheLeftToBall & playerIsOnTheLeftToBall);
        bool onePosition = ballIsBetweenPlayerAndAI & ((goalIsOnTheLeft & aiIsOnTheLeftToBall) || (!goalIsOnTheLeft & playerIsOnTheLeftToBall));

        if (onePosition)
        {
            return 1;
        }

        bool twoPosition = ballIsBetweenPlayerAndAI & ((goalIsOnTheLeft & playerIsOnTheLeftToBall) || (!goalIsOnTheLeft & aiIsOnTheLeftToBall));

        if (twoPosition)
        {
            return 2;
        }

        bool threePosition = !zeroPosition;

        if (threePosition)
        {
            return 3;
        }

        return -1;
    }
}
