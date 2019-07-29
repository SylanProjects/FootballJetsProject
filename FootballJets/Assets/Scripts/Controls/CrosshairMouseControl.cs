using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairMouseControl : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float speed = 5f;
    public float deadZone;
    public Text debug;
    public PlayerConfig playerConfig;

    /*
    private float h;
    private float v;
    public void Start()
    {
        h = 0;
        v = 0;
    }*/
    private void Update()
    {
        Push();
    }
    public void Push()
    {
        float x = this.transform.localPosition.x;
        float y = this.transform.localPosition.y;
        this.transform.localPosition = new Vector2(x + 0.1f, y);
        x = this.transform.localScale.x;


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
