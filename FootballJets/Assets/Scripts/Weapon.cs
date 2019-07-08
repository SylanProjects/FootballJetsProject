using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public string shootKey;
    public AudioSource soundSource;
    public AudioClip shootSFX;
    public SoundPlayer soundPlayer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(shootKey))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        // Shooting logic
        soundPlayer.PlaySound(soundSource, shootSFX);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

    }
}
