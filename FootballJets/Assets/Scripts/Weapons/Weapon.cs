using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public AudioSource soundSource;
    public SoundPlayer soundPlayer;
    public Transform firePoint;
    public Shooter shooter;
    public Stats stats;
    public PlayerConfig playerConfig;
    public WeaponList weaponList;

    private AbstractGun currentGun;
    

    public void Start()
    {

        currentGun = weaponList.GetDefaultWeapon();
    }
    
    public void Shoot()
    {
        if (stats.GetShieldStatus() < 1)
        {
            currentGun.Shoot();
        }
    }
    public void NextGun()
    {
        currentGun = weaponList.GetNextGun(currentGun);
        ShowCurrentWeapon(true);
    }
    public void SetGun(string gunName)
    {
        currentGun = weaponList.SetGun(gunName);
        ShowCurrentWeapon(true);
    }
    public AbstractGun GetCurrentGun()
    {
        return this.currentGun;
    }
    public void ShowCurrentWeapon(bool b)
    {
        currentGun.gameObject.SetActive(b);
    }
    public void Reload()
    {
        currentGun.Reload();
    }
    
}
