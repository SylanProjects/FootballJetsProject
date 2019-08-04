using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamController : MonoBehaviour
{
    public GameObject player1, player2, player3;
    public GameObject opponentGoal;
    public int stateBoundary = 12;
    private int score = 0;
    

    public void AddGoal(int s)
    {
        score += s;
    }
    public int GetScore()
    {
        return score;
    }
    public int GetStateBoundary()
    {
        return stateBoundary;
    }
}
