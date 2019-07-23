using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponList : MonoBehaviour
{
    private List<AbstractGun> guns;   
    public AbstractGun pistol;
    public AbstractGun machineGun;

    public void Start()
    {
        guns = new List<AbstractGun>
        {
            pistol,
            machineGun
        };
    }
    public AbstractGun GetNextGun(AbstractGun previousGun)
    {
        int nextGunIndex = guns.IndexOf(previousGun) + 1;
        if((nextGunIndex + 1) > guns.Count) {
            return guns[0];
        } else
        {
            return guns[nextGunIndex];
        }
        
    }
    public AbstractGun SetGun(string gunName)
    {
        foreach(AbstractGun gun in guns)
        {
            if(gun.GetGunName() == gunName)
            {
                return gun;
            }
        }
        return GetDefaultWeapon();
    }
    public AbstractGun GetDefaultWeapon()
    {
        if(guns == null)
        {
            Start();
        }
        return guns[0];
    }
    public List<AbstractGun> GetGuns()
    {
        return this.guns;
    }
    public void AddAmmo(string gunName, int amount)
    {
        foreach(AbstractGun gun in guns) {
            if(gun.GetGunName() == gunName)
            {
                gun.AddAmmo(amount);
            }
        }
    }

}
