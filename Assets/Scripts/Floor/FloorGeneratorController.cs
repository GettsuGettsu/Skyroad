using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGeneratorController : MonoBehaviour
{
    public GameObject floorPrefab;
    public Transform player;
    public List<GameObject> activeFloorSections = new List<GameObject>();
    private float spawnPosition = 0;
    private static float floorLength;
    private static readonly float startFloorCount = 21;

    public static float FloorLength { get { return floorLength; } }
    public static float StartFloorCount { get { return startFloorCount; } }

    private void Awake()
    {
        // get real length from prefab
        floorLength = floorPrefab.transform.localScale.z;
    }

    void Start()
    {       
        // spawn floor before start
        for (int i = 0; i < startFloorCount; i++)
        {
            SpawnFloorSection();
        }
    }

    void Update()
    {
        if (player == null)
            return;
        // checks the player's position to create a new floor section and remove the passed section
        if (player.position.z - floorLength > spawnPosition - (floorLength * startFloorCount))
        {
            // spawns new floor section
            SpawnFloorSection();
            // removes passed floor section
            DestroyFloorSection();
        }
    }
   
    private void SpawnFloorSection()
    {
        // clone the floor prefab with at spawtPosition with default rotation
        GameObject newFloor = Instantiate(floorPrefab, transform.forward * spawnPosition, floorPrefab.transform.rotation);
        // increase spawnPosition by length of the floor section
        spawnPosition += floorLength;
        // adds cloned object to a list
        activeFloorSections.Add(newFloor);
    }

    private void DestroyFloorSection()
    {
        // remove section passed by player from a scene and list
        Destroy(activeFloorSections[0]);
        activeFloorSections.RemoveAt(0);
    }
}
