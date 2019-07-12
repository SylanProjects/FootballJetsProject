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
    void Update()
    {
        Rotate();
    }
    private void Rotate()
    {
        float moveHorizontal = Input.GetAxisRaw(playerController.playerConfig.horizontalR);
        float moveVertical = Input.GetAxisRaw(playerController.playerConfig.verticalR);

        if ((moveHorizontal > playerController.deadZone || moveHorizontal < -playerController.deadZone) || (moveVertical > playerController.deadZone || moveVertical < -playerController.deadZone))
        {
            h = moveHorizontal;
            v = moveVertical;
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

