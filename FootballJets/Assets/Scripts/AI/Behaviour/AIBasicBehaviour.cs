using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AIBasicBehaviour
{
    public static Controls GetController(GameObject player)
    {
        return player.GetComponent<Controls>();
    }
    public static bool CheckIfBusy(GameObject player)
    {
        return player.GetComponent<PlayerController>().busyState.GetState();
    }
    public static void UseShield(GameObject player)
    {
        GetController(player).UseShield();
    }
    public static void UseSword(GameObject player)
    {

        AIMovementBehaviour.MoveBackward(player);
        GetController(player).UseSword();
    }
    public static void UseGun(GameObject player)
    {
        GetController(player).Shoot();
    }
    public static void Reload(GameObject player)
    {
        GetController(player).Reload();
    }
    public static void Sprint(GameObject player)
    {
        // change the value of sprint to 1
    }
    public static void SetGun(GameObject player, string gunName)
    {
        GetController(player).SetGun(gunName);
    }
    public static void NextGun(GameObject player)
    {
        GetController(player).NextGun();
    }
}
