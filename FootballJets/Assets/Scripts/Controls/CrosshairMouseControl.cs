using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairMouseControl : MonoBehaviour
{
    public float speed = 5f;
    public float deadZone;
    public Text debug;
    public PlayerConfig playerConfig;
    
    private void Update()
    {
        Push();
    }
    public void Push()
    {
        float x = this.transform.localPosition.x;
        float y = this.transform.localPosition.y;
        this.transform.localPosition = new Vector2(x + 0.1f, y);

        if (this.transform.localPosition.x >= 0)
        {
            this.transform.localPosition = new Vector2(0, 0);
        }
    }
    public void Pullback(float force)
    {
        float x = this.transform.localPosition.x;
        float y = this.transform.localPosition.y;
        this.transform.localPosition = new Vector2(-force, y);
        
    }
}
