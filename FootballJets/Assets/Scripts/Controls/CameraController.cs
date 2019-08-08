using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    /* This class is used to move the camera by following the player. 
     */
    void Start()
    {
        offset = transform.position - player.transform.position;
    }


    void LateUpdate() // Every frame but guaranteed to run after every item has been processed in update
    {
       // transform.position = player.transform.position + offset;
    }
}
