﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public GlobalTimer timer;
    public GlobalSettings settings;
    public TeamController redTeam, blueTeam;
    public float time;
    public GameObject ballPrefab;
    void Start()
    {
        
        timer.SetTime(GameStartSettings.gameTime);
        for (int i = 1; i < GameStartSettings.ballAmount; i++)
        {
            Instantiate(ballPrefab);
        }
        redTeam.player1.GetComponent<Controls>().SetAI(GameStartSettings.redTeamP1AI);
        blueTeam.player1.GetComponent<Controls>().SetAI(GameStartSettings.blueTeamP1AI);
    }
    

    
    public void ActivatePlayers(bool check)
    {
        redTeam.player1.SetActive(check);
        blueTeam.player1.SetActive(check);
    }
    
}