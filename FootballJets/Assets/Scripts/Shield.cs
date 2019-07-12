using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public PlayerController player;
    public Transform shield;
   
   
    
    
    void Update()
    {
        
        if (player.stats.GetShieldStatus() > 0)
        {
            shield.transform.gameObject.SetActive(true);
            player.stats.AddShield(-4);
            float size = (player.stats.GetShieldStatus() / 100) * 4f;
            shield.transform.localScale = new Vector2(0.25f, size);
        }
        if (player.stats.GetShieldStatus() < 1)
        {
            player.stats.SetShield(0);
            shield.transform.gameObject.SetActive(false);
            player.busyState.SetState(false);
        }
        
        if (Input.GetButtonDown(player.playerConfig.shieldKey))
        {
            if(player.stats.GetShieldStatus() == 0 && !player.busyState.GetState())
            {
                player.busyState.SetState(true);
                player.stats.SetShield(100);
                
            }
            
        }
    }
}
