using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupList : MonoBehaviour
{
    /* This class is used to keep track of available pickups and is used
     * to activate or deactivate them.
     */

    public PickupActivator topLeft;
    public PickupActivator topRight;
    public PickupActivator topMiddle;
    public PickupActivator bottomLeft;
    public PickupActivator bottomRight;
    public PickupActivator bottomMiddle;

    private List<PickupActivator> pickupList = new List<PickupActivator> {};
    private List<PickupActivator> activeList = new List<PickupActivator> { };

    public void MakeAvailable(PickupActivator pickup)
    {
        pickupList.Add(pickup);
        activeList.Remove(pickup);
    }
    public void MakeUnavailable(PickupActivator pickup)
    {
        pickupList.Remove(pickup);
        activeList.Add(pickup);
    }
    
    public List<PickupActivator> GetAvailablePickups()
    {
        return this.pickupList;
    }
    public int GetAvailableCount()
    {
        return this.pickupList.Count;
        
    }
    public List<PickupActivator> GetActivePickups()
    {
        return this.activeList;
    }

}
