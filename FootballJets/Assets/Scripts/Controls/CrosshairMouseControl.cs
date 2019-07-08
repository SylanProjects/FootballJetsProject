using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairMouseControl : MonoBehaviour
{
    // Start is called before the first frame update
    public string horizontal;
    public string vertical;
    public float speed = 5f;
    public float deadZone;
    public Text debug;


    private float h;
    private float v;
    public void Start()
    {
        h = 0;
        v = 0;
    }
    private void Update()
    {

        //Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        float moveHorizontal = Input.GetAxisRaw(horizontal);
        float moveVertical = Input.GetAxisRaw(vertical);
        
        debug.text = moveHorizontal + ", " + moveVertical;
        
        if ((moveHorizontal > deadZone || moveHorizontal < -deadZone) || (moveVertical > deadZone || moveVertical < -deadZone))
        {
            h = moveHorizontal;
            v = moveVertical;
        }

        // if (!(moveHorizontal < deadZone && moveHorizontal > -deadZone))
        //  {
        //    h = moveHorizontal;

        // }
        // if (!(moveVertical < deadZone && moveVertical > -deadZone))
        // {
        //    v = moveVertical;
        // }




        float angle = Mathf.Atan2(v, h) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
        

       // Vector3 lookDirection = new Vector2(Input.GetAxisRaw(horizontal), Input.GetAxisRaw(vertical));
        //transform.rotation = Quaternion.LookRotation(lookDirection);

    }
}
