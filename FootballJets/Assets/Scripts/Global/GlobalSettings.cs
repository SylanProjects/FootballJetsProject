using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSettings : MonoBehaviour
{
    /*
     * These are the starting settings of the game. 
     */
     // Player
   // public int health = GameStartSettings.health;
    //public float stamina = GameStartSettings.stamina;
    public float staminaDrain = 3;
    public float staminaRecharge = 1;
   // public float speed = 1700; // 50
    public float sprintPower = 0.5f;
    public float rotateSpeed = 15;
    public bool useLeftToRotate = true;

    // Weapons
    public float shield = 0;
   // public int pistolAmmo = GameStartSettings.pistolAmmo;
   // public int machineGunAmmo = GameStartSettings.machineGunAmmo;

   // Sword
    public float swordHitSize = 5;
    public float swordSpeed = 1;
    public float swordStrength = 15;
    public int swordAttackStrength = 10;

    // Pickup
    public float pickupSpawnFrequency = 20;

    // AI
    public float stateBoundary = 12;
    public int allowableDistanceFromBall = 7;

    //public int gameTime = GameStartSettings.gameTime;
    
}
