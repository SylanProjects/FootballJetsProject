using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    public Stats stats;
    public Text healthText;
    public Text staminaText;
    public Text shieldText;
    public Text ammoText;
    
    void Update()
    {
        healthText.text = "Health: " + stats.GetHealthStatus();
        staminaText.text = "Stamina: " + stats.GetStaminaStatus();
        float shield = 100 - stats.GetShieldStatus();
        shieldText.text = "Shield: " + shield;
        ammoText.text = stats.weapon.GetCurrentGun().ToString();
    }
    
}
