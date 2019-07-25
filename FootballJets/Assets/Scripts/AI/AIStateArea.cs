using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateArea : MonoBehaviour
{
    public StateController state;

    public void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag ("Ball"))
        {
            state.SetState(this.gameObject.name); 
        }
    }
}
