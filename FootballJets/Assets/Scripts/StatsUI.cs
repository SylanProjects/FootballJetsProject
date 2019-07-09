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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + stats.health;
        staminaText.text = "Stamina: " + stats.stamina;
        shieldText.text = "Shield: " + (100 - stats.shield);

    }
}
