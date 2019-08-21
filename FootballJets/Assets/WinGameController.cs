using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGameController : MonoBehaviour
{
    
    void Update()
    {
        if(GameStatus.winStatus)
        {
            ShowWinScreen();
        }
    }
    public void ShowWinScreen()
    {
        // TODO
    }
}
