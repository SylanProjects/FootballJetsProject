using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControl : MonoBehaviour
{

    public enum State {
        SHOOT,
        ATTACK,
        TACKLE, 
        DEFEND
    }

    public State state;
    private bool alive;
    
    void Start()
    {

    }


}
