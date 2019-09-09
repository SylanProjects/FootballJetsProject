using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGameController : MonoBehaviour
{
    public TeamController redTeam, blueTeam;
    public GlobalTimer timer;
    public SceneSwitcher sceneSwitcher;
    void Update()
    {
        if(redTeam.GetScore() >= GameStartSettings.winningScore)
        {
            GameStatus.winTeam = "Red Team";
            GameStatus.redTeamScore += 1;
            SetStatus();
        }
        else if (blueTeam.GetScore() >= GameStartSettings.winningScore)
        {
            GameStatus.winTeam = "Blue Team";
            GameStatus.blueTeamScore += 1;
            SetStatus();
        }
        else if (timer.GetTime() <= 0)
        {
            TimeUp();
        }
        if(GameStatus.winStatus)
        {
            GameStatus.winStatus = false;
            ShowWinScreen();
        }
    }
    public void ShowWinScreen()
    {
       
        sceneSwitcher.SceneSwitch(3);
    }
    private void SetStatus()
    {
        GameStatus.blueTeamGameScore = blueTeam.GetScore();
        GameStatus.redTeamGameScore = redTeam.GetScore();

        GameStatus.winStatus = true;
    }
    private void TimeUp()
    {
        if (redTeam.GetScore() > blueTeam.GetScore())
        {
            GameStatus.winTeam = "Red Team";
            GameStatus.redTeamScore += 1;

        }
        else if (redTeam.GetScore() < blueTeam.GetScore())
        {
            GameStatus.winTeam = "Blue Team";
            GameStatus.blueTeamScore += 1;
        }
        SetStatus();
    }
}
