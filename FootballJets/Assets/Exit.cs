using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public GlobalSettings globalPlayerSettings;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Exit"))
        {
            Application.Quit();
        }
    }
}
