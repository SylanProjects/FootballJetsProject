using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    
    public void Fire(GameObject bulletPrefab, Transform firePoint)
    {
        /*
         This method is only used to initiate a bullet.
         It is useful because this can be modified to add something like wind
         which affects how the bullet spawns etc. 
         */
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
