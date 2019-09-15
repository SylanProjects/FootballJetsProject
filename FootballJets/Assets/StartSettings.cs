using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSettings : MonoBehaviour
{
    public Text healthText;
    public Text staminaText;
    public Text timeText;
    public Text pistolAmmoText;
    public Text machineGunAmmoText;
    public Text ballSizeText;

    //TODO
    public Text winningScoreText;
    public Text shieldSizeText;
    public Text ballAmountText;
    public Text ballWeightText;
    public Text playerSpeedText;
    public Text blueTeamScore;
    public Text redTeamScore;
    public Text shieldDurationText;

    private void Start()
    {
        GameStartSettings.redTeamP1AI = true;
    }
    public void Update()
    {
        healthText.text =  "" + GameStartSettings.health;
        staminaText.text = "" + GameStartSettings.stamina;
        
        pistolAmmoText.text = "" + GameStartSettings.pistolAmmo;
        machineGunAmmoText.text = "" + GameStartSettings.machineGunAmmo;
        ballSizeText.text = "" + GameStartSettings.ballSize;

        TimeSpan timeSpan = TimeSpan.FromSeconds(GameStartSettings.gameTime);
        timeText.text = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);


        winningScoreText.text = "" + GameStartSettings.winningScore;
        shieldSizeText.text = "" + GameStartSettings.shieldSize;
        shieldDurationText.text = "" + GameStartSettings.shieldDuration;
        ballWeightText.text = "" + GameStartSettings.ballWeight;
        ballAmountText.text = "" + GameStartSettings.ballAmount;
        
        playerSpeedText.text = "" + GameStartSettings.playerSpeed;
        blueTeamScore.text = "" + GameStatus.blueTeamScore;
        redTeamScore.text = "" + GameStatus.redTeamScore;

        // GameObject.Find("BlueTeamP1Toggle").GetComponent<Toggle>().onValueChanged.AddListener((value) => { GameStartSettings.blueTeamP1AI = value; } );
        
        GameObject.Find("RedTeamP1Toggle").GetComponent<Toggle>().onValueChanged.AddListener((value) => { GameStartSettings.redTeamP1AI = value; } );


    }
    
    public void AddHealth(int health)
    {
        GameStartSettings.health += health;
        if (GameStartSettings.health < 10) {GameStartSettings.health = 10;}
    }
    public void AddStamina(int s)
    {
        GameStartSettings.stamina += s;
        if (GameStartSettings.stamina < 10) { GameStartSettings.stamina = 10; }
    }
    public void AddTime(int t)
    {
        GameStartSettings.gameTime += t;
        if (GameStartSettings.gameTime < 10) { GameStartSettings.gameTime = 10; }
    }
    public void AddPistolAmmo(int a)
    {
        GameStartSettings.pistolAmmo += a;
        if (GameStartSettings.pistolAmmo < 0) { GameStartSettings.pistolAmmo = 0; }
    }
    public void AddMachineGunAmmo(int a)
    {
        GameStartSettings.machineGunAmmo += a;
        if (GameStartSettings.machineGunAmmo < 0) { GameStartSettings.machineGunAmmo = 0; }
    }
    public void IncreaseBallSize()
    {
        GameStartSettings.ballSize = GameObject.Find("BallSizeSlider").GetComponent<Slider>().value;

    }
    
     public void IncreaseShieldSize()
    {
        GameStartSettings.shieldSize = GameObject.Find("ShieldSizeSlider").GetComponent<Slider>().value;

    }
    public void SetShieldDuration()
    {
        GameStartSettings.shieldDuration = (int) GameObject.Find("ShieldDurationSlider").GetComponent<Slider>().value;
    }
    public void AddBallAmount(int s)
    {
        GameStartSettings.ballAmount += s;
        if (GameStartSettings.ballAmount < 1) { GameStartSettings.ballAmount = 1; }

    }
    public void IncreaseBallWeight ()
    {
        GameStartSettings.ballWeight = GameObject.Find("BallWeightSlider").GetComponent<Slider>().value;
    }
    public void SetPlayerSpeed()
    {
        GameStartSettings.playerSpeed = (int) GameObject.Find("PlayerSpeedSlider").GetComponent<Slider>().value;
    }
    public void SetWinningScore(int s)
    {
        GameStartSettings.winningScore += s;
        if (GameStartSettings.winningScore < 2) { GameStartSettings.winningScore = 2; }
    }
    public void SetBlueTeamP1AI(bool a)
    {
        GameStartSettings.blueTeamP1AI = a;

    }
    public void SetRedTeamP1AI(bool a)
    {
        GameStartSettings.redTeamP1AI = a;
    }



}
