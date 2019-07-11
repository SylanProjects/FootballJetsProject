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
        currentGun = weaponList.GetDefaultWeapon();
    }
    void Update()
    {
        //if (Input.GetButtonDown(playerConfig.shootKey))
        if (Input.GetAxis(playerConfig.shootKey) > 0.1)
        {
            
            if (stats.shield < 1)
            {
                currentGun.Shoot();
                

            }
            
        }
     
        if (Input.GetButtonDown(playerConfig.changeGunKey))
        {
            currentGun = weaponList.GetNextGun(currentGun);
            currentGun.gameObject.SetActive(true);
        }
    }
    public AbstractGun GetCurrentGun()
    {
        return this.currentGun;
    }
    
}
