using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUIController : MonoBehaviour
{
    // This method keeps an info on the team scores.
    public TeamController blueTeam;
    public TeamController redTeam;
    public Text scoreText;

    void Start()
    {
        scoreText.text = blueTeam.GetScore().ToString() + " : " + blueTeam.GetScore();
    }

    void Update()
    {
        int p1Score = blueTeam.GetScore();
        int p2Score = redTeam.GetScore();
        
        scoreText.text = p1Score + " : " + p2Score;
    }
}
