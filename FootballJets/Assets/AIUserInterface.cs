using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIUserInterface : MonoBehaviour
{
    public StateController state;
    public Text stateText;
    
    void Update()
    {
        stateText.text = state.GetState();
    }
}
