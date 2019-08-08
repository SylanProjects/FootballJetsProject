using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public GlobalSettings globalPlayerSettings;
    void Update()
    {
        if(Input.GetButtonDown("Exit"))
        {
            Application.Quit();
        }
    }
}
