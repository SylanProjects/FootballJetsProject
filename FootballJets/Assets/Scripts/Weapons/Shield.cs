using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public PlayerController player;
    public Transform shield;
   
    public void Update()
    {
        
        if (player.stats.GetShieldStatus() > 0)
        {
            shield.transform.gameObject.SetActive(true);
            float shieldDuration = GameStartSettings.shieldDuration - 3.5f;
            player.stats.AddShield(-4 + shieldDuration);
            float size = (player.stats.GetShieldStatus() / 100) * 4f * GameStartSettings.shieldSize;
            shield.transform.localScale = new Vector2(0.25f, size);
        }
        if (player.stats.GetShieldStatus() < 1)
        {
            player.stats.SetShield(0);
            shield.transform.gameObject.SetActive(false);
            player.busyState.SetState(false);
        }  
    }
    public void UseShield()
    {
        if (player.stats.GetShieldStatus() == 0 && !player.busyState.GetState())
        {
            player.busyState.SetState(true);
            player.stats.SetShield(100);

        }
    }
}
