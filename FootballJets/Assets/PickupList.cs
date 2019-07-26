using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupList : MonoBehaviour
{
    public PickupActivator topLeft;
    public PickupActivator topRight;
    public PickupActivator topMiddle;
    public PickupActivator bottomLeft;
    public PickupActivator bottomRight;
    public PickupActivator bottomMiddle;

    private List<PickupActivator> pickupList;
    

    public void Start()
    {
        
        pickupList = new List<PickupActivator> { };

    }
  
    public void MakeAvailable(PickupActivator pickup)
    {
        Start();
        pickupList.Add(pickup);
    }
    public void MakeUnavailable(PickupActivator pickup)
    {
        pickupList.Remove(pickup);
    }
    
    public List<PickupActivator> GetAvailablePickups()
    {
        return this.pickupList;
    }
    public int GetAvailableCount()
    {
        return this.pickupList.Count;
        
    }

}
