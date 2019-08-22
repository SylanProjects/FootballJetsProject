using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinGameMain : MonoBehaviour
{
    public Text winTeamText;
    public Text scoreText;
    void Start()
    {
        if (GameStatus.blueTeamGameScore == GameStatus.redTeamGameScore)
        {
            winTeamText.text = "Draw!";
        }
        else
        {
            winTeamText.text = GameStatus.winTeam + " wins!";
        }
        scoreText.text = "Blue " + GameStatus.blueTeamGameScore + " : " + GameStatus.redTeamGameScore + " Red";
        GameStatus.blueTeamGameScore = 0;
        GameStatus.redTeamGameScore = 0;
        
    }

    
    void Update()
    {
        
    }
}
