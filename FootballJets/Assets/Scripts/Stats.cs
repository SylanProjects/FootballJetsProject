using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float health;
    public float stamina;
    public float shield;
    public PlayerController player;

    
    private void Start()
    {
        health = 100f;
        stamina = 100f;
        shield = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (shield == 100)
        {
            shield = 100;
        }
        else if(shield < 100)
        {
            shield += 1;
        }
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
}
