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
    

    private void Start()
    {
        currentGun = weaponList.pistol;//GetDefaultWeapon();
    }
    void Update()
    {
        if (Input.GetAxis(playerConfig.shootKey) > 0.1)
        {
            
            if (stats.GetShieldStatus() < 1)
            {
                currentGun.Shoot();
            }
        }
     
        if (Input.GetButtonDown(playerConfig.changeGunKey))
        {
            currentGun = weaponList.GetNextGun(currentGun);
            ShowCurrentWeapon(true);

        }
    }
    public AbstractGun GetCurrentGun()
    {
        return this.currentGun;
    }
    public void ShowCurrentWeapon(bool b)
    {
        currentGun.gameObject.SetActive(b);
    }
    
}
