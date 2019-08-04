using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSettings : MonoBehaviour
{
    /*
     * These are the starting settings of the game. 
     */
     // Player
    public float health = 100;
    public float stamina = 100;
    public float staminaDrain = 3;
    public float staminaRecharge = 1;
    public float speed = 50;
    public float sprintPower = 0.5f;
    public float rotateSpeed = 15;
    public bool useLeftToRotate = false;

    // Weapons
    public float shield = 0;
    public int pistolAmmo = 999;
    public int machineGunAmmo = 99;

   // Sword
    public float swordHitSize = 5;
    public float swordSpeed = 1;
    public float swordStrength = 15;

    // Pickup
    public float pickupSpawnFrequency = 20;

    // AI
    public float stateBoundary = 12; 
    

}
