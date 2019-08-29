using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamController : MonoBehaviour
{
    // This method keeps track of team information like players, score etc.
    public GameObject player1, player2, player3;
    public GameObject opponentGoal;
    public int stateBoundary = 12;
    public TeamController opponentTeam;
    private int score = 0;
    
    
    public void AddPoint(int points)
    {
        score += points;
    }
    public void AddPointToOpponentTeam(int points)
    {
        opponentTeam.AddPoint(points);
    }
    public int GetScore()
    {
        return score;
    }
    public int GetStateBoundary()
    {
        return stateBoundary;
    }
    public void ResetPlayers()
    {
        player1.GetComponent<PlayerController>().ResetPosition();
        player1.GetComponent<PlayerController>().ResetHealth();
    }
}
