using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawn : MonoBehaviour
{
    /* This method is used to get a random pickup object 
     * from the available pickups list and activate it.
     */
    public PickupControl pickupControl;

    public void LateUpdate()
    {
        List<PickupActivator> pickupList = pickupControl.pickupList.GetAvailablePickups();
        
        PickupActivator activator = null;
        if (pickupControl.pickupList.GetAvailableCount() > 3 && pickupControl.pickupTimer.GetTimeLeft() < 0)
        {
            activator = pickupList[Random.Range(0, pickupList.Count)];
            activator.Activate();
            pickupControl.pickupTimer.ResetTimer();
        }
    }
}
