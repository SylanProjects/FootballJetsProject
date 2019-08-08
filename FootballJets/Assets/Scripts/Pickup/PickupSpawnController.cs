using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawnController : MonoBehaviour
{
    /* This class has info on the pickup object positions and keeps track of all
     * possible pickups. 
     */
    public GameObject healthPack;
    private List<CoordinatePair> allCoordinates;
    private List<CoordinatePair> availableCoordinates;


    // Coordinates
    private CoordinatePair topLeft = new CoordinatePair(-22, 12);
    private CoordinatePair topRight = new CoordinatePair(22, 12);
    private CoordinatePair bottomLeft = new CoordinatePair(-22, -12);
    private CoordinatePair bottomRight = new CoordinatePair(22, -12);
    private CoordinatePair topMiddle = new CoordinatePair(0, 12);
    private CoordinatePair bottomMiddle = new CoordinatePair(0, -12);


    private void Start()
    {
        allCoordinates = new List<CoordinatePair> {
            topLeft,
            topRight,
            bottomLeft,
            bottomRight,
            topMiddle,
            bottomMiddle

        };
        
        spawnObject(allCoordinates[5]);
    }
    public void spawnObject(CoordinatePair coordinates)
    {
        Vector3 pos = new Vector3(coordinates.GetX(), coordinates.GetY(), 0);
        Instantiate(healthPack, pos, transform.rotation);
    }
}
