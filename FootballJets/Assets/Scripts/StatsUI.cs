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
    
    void Start()
    {
        
    }

    void Update()
    {
        
        healthText.text = "Health: " + stats.health;
        staminaText.text = "Stamina: " + stats.stamina;
        float shield = 100 - stats.shield;
        shieldText.text = "Shield: " + shield;
        ammoText.text = stats.weapon.GetCurrentGun().ToString();
        
        
        
        

    }
    
}
