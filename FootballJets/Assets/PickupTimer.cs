using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupTimer : MonoBehaviour
{
    public PickupControl pickupControl;
    public Text timer;
    private float timeLeft;
    private float pickupSpawnFrequency;
    void Start()
    {
        ResetTimer();
        pickupSpawnFrequency = pickupControl.globalSettings.pickupSpawnFrequency;
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        timer.text = timeLeft.ToString();
        /*
         * Timer need to be reset just in case it is not resetted
         * when spawning a new pickup item.
         */
        if(timeLeft < -2)
        {
            ResetTimer();
        }
    }
    public void ResetTimer()
    {

        timeLeft = Random.Range(pickupSpawnFrequency * 0.5f, pickupSpawnFrequency * 1.5f);
    }
    public float GetTimeLeft()
    {
        return this.timeLeft;
    }
}
