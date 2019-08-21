using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{

    public PlayerController player;
    public Weapon weapon;

    private float health;
    private float stamina;
    private float shield;

    public void Start()
    {
        health = GameStartSettings.health;
        stamina = GameStartSettings.stamina;
        shield = 0;
        weapon.weaponList.Start();
        weapon.weaponList.AddAmmo("Pistol", GameStartSettings.pistolAmmo);
        weapon.weaponList.AddAmmo("MachineGun", GameStartSettings.machineGunAmmo);

    }
    public void Update()
    {
        ReplenishHealth();
    }
    public void ReplenishHealth()
    {
        if (health >= GameStartSettings.health)
        {
            health = GameStartSettings.health;
        }
        else if (health < 0f)
        {
            // This means character is dead
            player.team.AddPointToOpponentTeam(1);
            player.ResetPosition();
            health = GameStartSettings.health;
        }
        else
        {
            health += 0.01f;
        }
    }
    
    public void AddHealth(float amount)
    {
        
        this.health += amount;
        if (this.health > GameStartSettings.health)
        {
            this.health = GameStartSettings.health;
        }
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
