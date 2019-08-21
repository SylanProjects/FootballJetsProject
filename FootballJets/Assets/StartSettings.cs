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
    
    
    public void Update()
    {
        healthText.text =  "" + GameStartSettings.health;
        staminaText.text = "" + GameStartSettings.stamina;
        
        pistolAmmoText.text = "" + GameStartSettings.pistolAmmo;
        machineGunAmmoText.text = "" + GameStartSettings.machineGunAmmo;
        ballSizeText.text = "" + GameStartSettings.ballSize;

        TimeSpan timeSpan = TimeSpan.FromSeconds(GameStartSettings.gameTime);
        timeText.text = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);

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
    
}
