using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : IPickupEffect
{
    public void ApplyEffect(GameObject gameObject)
    {
        if (gameObject.GetComponent<Stats>() == null || gameObject == null)
        {
            throw new System.ArgumentNullException();
        }
        else {
            gameObject.GetComponent<Stats>().AddHealth(Random.Range(20, 50));
        }
    }
}
 