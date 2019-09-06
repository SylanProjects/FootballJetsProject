using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotator : MonoBehaviour
{
    /* This class is used to rotate the player around the pivor point.
     */
    public PlayerController playerController;
    
    private float h;
    private float v;
    void Start()
    {
        h = 0;
        v = 0;
        
    }

   
    public void Rotate(float lookHorizontal, float lookVertical)
    {
        if ((lookHorizontal > playerController.playerMovement.deadZone || lookHorizontal < -playerController.playerMovement.deadZone) || (lookVertical > playerController.playerMovement.deadZone || lookVertical < -playerController.playerMovement.deadZone))
        {
            h = lookHorizontal;
            v = lookVertical;
        }

        float angle = Mathf.Atan2(v, h) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, playerController.globalSettings.rotateSpeed * Time.deltaTime);

    }
    public CoordinatePair GetRotation()
    {
        return new CoordinatePair(this.h, this.v);
    }
}

