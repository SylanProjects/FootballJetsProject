using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSettings : MonoBehaviour
{
    /*
     * These are the starting settings of the game. 
     */
    public float health = 100;
    public float stamina = 100;
    public float staminaDrain = 3;
    public float staminaRecharge = 1;
    public float shield = 0;
    public float speed = 50;
    public float sprintPower = 0.5f;
    public int pistolAmmo = 999;
    public int machineGunAmmo = 99;
   
    public float swordHitSize = 5;
    public float swordSpeed = 1;
    public float swordStrength = 15;
    public float pickupSpawnFrequency = 20;
    public float rotateSpeed = 15;
    public bool useLeftToRotate = false;
}
