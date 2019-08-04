using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUIController : MonoBehaviour
{
    public TeamController blueTeam;
    public TeamController redTeam;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = blueTeam.GetScore().ToString() + " : " + blueTeam.GetScore();
    }

    // Update is called once per frame
    void Update()
    {
        int p1Score = blueTeam.GetScore();
        int p2Score = redTeam.GetScore();
        
        scoreText.text = p1Score + " : " + p2Score;
    }
}
