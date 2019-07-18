using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotator : MonoBehaviour
{
    public PlayerController playerController;
    
    private float h;
    private float v;
    void Start()
    {
        h = 0;
        v = 0;
        
    }

    // Update is called once per frame
    
    public void Rotate(float lookHorizontal, float lookVertical)
    {
        

        if ((lookHorizontal > playerController.deadZone || lookHorizontal < -playerController.deadZone) || (lookVertical > playerController.deadZone || lookVertical < -playerController.deadZone))
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

