using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float health;
    public float stamina;
    public float shield;
    public int score;
    public PlayerController player;
    public Weapon weapon;
    
    
    private void Start()
    {
        health = 100f;
        stamina = 100f;
        shield = 0;
        score = 0;
        weapon.weaponList.pistol.AddAmmo(999);
        weapon.weaponList.machineGun.AddAmmo(600);
        

    }


   
    void Update()
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

    public void AddHealth(int amount)
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
    
}
