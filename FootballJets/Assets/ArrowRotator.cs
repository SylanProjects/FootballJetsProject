using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotator : MonoBehaviour
{
    public AIController aiController;
    private float h;
    private float v;
    void Start()
    {
        h = 0;
        v = 0;

    }
    
    public void Rotate(float lookHorizontal, float lookVertical)
    {

        
        if ((lookHorizontal > 0.3 || lookHorizontal < -0.3) || (lookVertical > 0.3 || lookVertical < -0.3))
        {
            h = lookHorizontal;
            v = lookVertical;
        }

        float angle = Mathf.Atan2(v, h) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 100 * Time.deltaTime);

    }
    public void SetPosition(float x, float y)
    {
        this.gameObject.transform.position = new Vector2(x, y);
    }
}
