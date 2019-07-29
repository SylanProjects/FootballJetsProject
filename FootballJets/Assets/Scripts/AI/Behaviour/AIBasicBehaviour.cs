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
        PlayerController playerController = player.GetComponent<PlayerController>();
        GetController(player).UseSword();
    }
    public static void UseGun(GameObject player)
    {
        GetController(player).Shoot();
    }
    public static void Reload(GameObject player)
    {
        player.GetComponent<Controls>().Reload();
    }
    public static void Sprint(GameObject player)
    {
        // change the value of sprint to 1
    }
    public static void SetGun(GameObject player, string gunName)
    {
        player.GetComponent<Controls>().SetGun(gunName);
    }
    public static void NextGun(GameObject player)
    {
        player.GetComponent<Controls>().NextGun();
    }
}
