using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupControl : MonoBehaviour
{
    /* List of components used with this object 
     * to make it easier to access them from one place.
    */
    public PickupPrefabs pickupPrefabs;
    public PickupList pickupList;
    public PickupTimer pickupTimer;
    public GlobalSettings globalSettings;
}
