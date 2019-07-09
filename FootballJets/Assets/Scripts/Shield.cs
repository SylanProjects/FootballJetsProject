using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public Transform shield;
    public string shieldKey;
    public Stats stats; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (stats.shield > 0)
        {
            shield.transform.gameObject.SetActive(true);
            stats.shield -= 4;
            float size = (stats.shield / 100) * 4f;
            shield.transform.localScale = new Vector2(0.25f, size);
        }
        if (stats.shield < 1)
        {
            stats.shield = 0;
            shield.transform.gameObject.SetActive(false);
            
        }
        if (Input.GetAxis(shieldKey) > 0.3)
        {
            if(stats.shield == 0)
            {
                stats.shield = 100;
                //shield.transform.localPosition = new Vector2(5.6f, 0);
            }
            
        }
    }
}
