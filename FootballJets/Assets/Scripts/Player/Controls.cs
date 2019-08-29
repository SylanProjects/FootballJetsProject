using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    /*
     * This class takes care of all of the controls. 
     */
    public PlayerController playerController;
    public PlayerRotator playerRotator;
    public Sword sword;
    public Shield shield;
    public Weapon weapon;

    private bool aiControlled;
    private PlayerConfig playerConfig;
    private bool useLeftToRotate;

    public void Start()
    {
        aiControlled = false;
        playerConfig = playerController.playerConfig;
        useLeftToRotate = playerController.globalSettings.useLeftToRotate;
    }
    void FixedUpdate()
    {
        if (!aiControlled)
        {

            float sprint = Input.GetAxis(playerConfig.sprintKey);
            float moveHorizontal = Input.GetAxis(playerConfig.horizontalL);
            float moveVertical = Input.GetAxis(playerConfig.verticalL);
            // Movement
            playerController.MovePlayer(moveHorizontal, moveVertical);

            /*
             * Looking direction - player does not have to move in the direction
             * that the player character is looking, this can be toggled
             * on or off in the global settings under "Use Left To Rotate".
             */
            float lookHorizontal;
            float lookVertical;
            if (useLeftToRotate)
            {
                lookHorizontal = moveHorizontal;
                lookVertical = moveVertical;
            }
            else
            {
                lookHorizontal = Input.GetAxisRaw(playerController.playerConfig.horizontalR);
                lookVertical = Input.GetAxisRaw(playerController.playerConfig.verticalR);
            }
            playerRotator.Rotate(lookHorizontal, lookVertical);

            // Sprint
            playerController.Sprint(sprint);


            // Sword, Shield, Weapon
            if (Input.GetButtonDown(playerConfig.swordKey))
            {
                UseSword();
            }
            if (Input.GetButtonDown(playerConfig.shieldKey))
            {
                UseShield();
            }
            if (Input.GetAxis(playerConfig.shootKey) > 0.1)
            {
                Shoot();
            }
            if (Input.GetButtonDown(playerConfig.changeGunKey))
            {
                NextGun();
            }
            if (Input.GetButtonDown(playerConfig.reloadGunKey))
            {
                Reload();
            }

        }
    }
    public void UseSword()
    {
        sword.UseSword();
    }
    public void UseShield()
    {
        shield.UseShield();
    }
    public void Shoot()
    {
        weapon.Shoot();
    }
    public void NextGun()
    {
        weapon.NextGun();
    }
    public void SetGun(string gunName)
    {
        weapon.SetGun(gunName);
    }
    public void Reload()
    {
        weapon.Reload();
    }
    public void SetAI(bool v)
    {
        aiControlled = v;
    }

}
