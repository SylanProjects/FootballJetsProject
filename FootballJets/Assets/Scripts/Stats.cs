using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
   
    
    public int score;
    public PlayerController player;
    public Weapon weapon;

    private float health;
    private float stamina;
    private float shield;



    public void Start()
    {
        health = player.globalSettings.health;
        stamina = player.globalSettings.stamina;
        shield = 0;
        score = 0;
        weapon.weaponList.Start();
        weapon.weaponList.AddAmmo("Pistol", player.globalSettings.pistolAmmo);
        weapon.weaponList.AddAmmo("MachineGun", player.globalSettings.machineGunAmmo);
        //weapon.weaponList.pistol.AddAmmo(player.globalSettings.pistolAmmo);
        //weapon.weaponList.machineGun.AddAmmo(player.globalSettings.machineGunAmmo);
        

    }

    
   
    public void Update()
    {
        
        ReplenishHealth();

    }
    public void ReplenishHealth()
    {
        if (health >= 100f)
        {
            health = 100f;
        }
        else if (health < 0f)
        {
            player.ResetPosition();
            health = 100f;

        }
        else
        {
            health += 0.01f;
        }
    }
    public void AddGoal(int points)
    {
        score += points;
    }

    public void AddHealth(float amount)
    {
        
        this.health += amount;
        if (this.health > 100)
        {
            this.health = 100;
        }
    }
    public int GetScore()
    {
        return score;
    }
    public float GetShieldStatus()
    {
        return this.shield;
    }
    public void AddShield(float amount)
    {
        this.shield += amount;
    }
    public void SetShield(float amount)
    {
        this.shield = amount;
    }
    public float GetHealthStatus()
    {
        return this.health;
    }  
    public float GetStaminaStatus()
    {
        return this.stamina;
    }
    public void AddStamina(float amount)
    {
        this.stamina += amount;
    }
    public void SetStamina(float amount)
    {
        this.stamina = amount;
    }
}
