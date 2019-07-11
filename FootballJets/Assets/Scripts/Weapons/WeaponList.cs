using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponList : MonoBehaviour
{
    private List<AbstractGun> guns;   
    public AbstractGun pistol;
    public AbstractGun machineGun;

    private void Start()
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
    public AbstractGun GetDefaultWeapon()
    {
        return guns[0];
    }
    public List<AbstractGun> GetGuns()
    {
        return this.guns;
    }

}
