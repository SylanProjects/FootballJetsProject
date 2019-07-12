using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractGun : MonoBehaviour, IGun 
{
    public string gunName;
    public Weapon weapon;
    public AudioClip shootSFX;
    public GameObject bulletPrefab; // Each gun has a different bullet
    public float delayTime;
    public float reloadDelayTime;
    public int magazineSize;
    public CrosshairMouseControl body;

    private bool reloading;
    private int ammo;
    private int availableAmmo;
    private float countdown;
    private bool readyToShoot;

    
    void Start()
    {
        InitializeGun();
    }
    void Update()
    {
        body.Push();
        
        if(!readyToShoot)
        {
            Delay();
        }
        if (weapon.GetCurrentGun() == this)
        {
            this.gameObject.SetActive(true);
        }else
        {
            this.gameObject.SetActive(false);
        }
        
    }


    
   

    public void Reload()
    {
        /*
         * Player can reload a gun before the amount of bullets in the magazine (availableAmmo)
         * reaches 0, therefore the first part takes care of that. 
         */

        DelayFor(reloadDelayTime);
        reloading = true;
        if (ammo > magazineSize)
        {
            int aAmmo = availableAmmo; // Ammo already in the magazine
            availableAmmo += magazineSize - aAmmo;
            ammo -= magazineSize - aAmmo;
            
        }
        
        else if(ammo > 0 && ammo < magazineSize)
        {
            int aAmmo = availableAmmo;
            availableAmmo += ammo - aAmmo;
            ammo = aAmmo;
        }
        
    }

    public virtual void Shoot()
    {
        /*
         * If there is enough bullets in the magazine, shoot.
         * Otherwise reload which takes care of the issue when there is 
         * no more bullets left. 
         */
        if (availableAmmo > 0 && readyToShoot)
        {
            
            body.Pullback(0.5f);

            weapon.soundPlayer.PlaySound(weapon.soundSource, shootSFX);
            weapon.shooter.Fire(bulletPrefab, weapon.firePoint);
            availableAmmo -= 1;
            readyToShoot = false;
            countdown = delayTime;
        }
        else if(availableAmmo == 0 && ammo > 0)
        {
            Reload();
            Shoot();
        } 
        
    }
    public void Delay()
    {
        if (countdown > 0)
        {
            countdown -= 1 * Time.deltaTime;
            
        }
        if (countdown <= 0)
        {
            readyToShoot = true;
            countdown = 0;
            reloading = false;
        }

    }
    
    
    public void DelayFor(float time)
    {
        readyToShoot = false;
        countdown = reloadDelayTime;
        Delay();
    }

    public bool CheckIfReloading()
    {
        return this.reloading;
    }
    public bool CheckIfReady()
    {
        return this.readyToShoot;
    }
    public void AddAmmo(int amount)
    {
        this.ammo += amount;
    }
    public int GetAmmo()
    {
        return this.ammo;
    }
    public string GetGunName()
    {
        return this.gunName;
    }
    public string GetAmmoString()
    {
        return this.availableAmmo + " / " + this.ammo;
    }
    public override string ToString()
    {
        if(reloading)
        {
            return this.gunName + ": Reloading...";
        } else
        {
            return this.gunName + ": " + this.availableAmmo + " / " + this.ammo;
        }
        
    }
    public void InitializeGun()
    {
        this.availableAmmo = magazineSize;
    }
    
    
}
