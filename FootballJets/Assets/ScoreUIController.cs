using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUIController : MonoBehaviour
{
    public Stats player1Stats;
    public Stats player2Stats;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = player1Stats.GetScore().ToString() + " : " + player2Stats.GetScore();
    }

    // Update is called once per frame
    void Update()
    {
        int p1Score = player1Stats.GetScore();
        int p2Score = player2Stats.GetScore();
        
        scoreText.text = p1Score + " : " + p2Score;
    }
}
