using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObstaclesGeneratorController : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform player;
    public List<GameObject> activeObstacles = new List<GameObject>();
    private float spawnPosition = 0;
    private float spawnDistance;
    private readonly float minObstaclesSpacing = 12;
    private readonly float maxObstaclesSpacing = 28;
    private readonly float startObstaclesCount = 10;

    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = FloorGeneratorController.FloorLength * FloorGeneratorController.StartFloorCount / 7;
        spawnDistance = FloorGeneratorController.FloorLength * FloorGeneratorController.StartFloorCount;

        for (int i = 0; i < startObstaclesCount; i++)
            SpawnObstacle();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) 
            return;
        if (player.position.z + spawnDistance > spawnPosition)
            SpawnObstacle();
        if (player.position.z - player.transform.localScale.z * 4 > activeObstacles[0].transform.position.z)
        {
            StatsController.IncreaseScoreObstacle();
            DestroyObstacle();
        }
    }

    private void SpawnObstacle()
    {
        Vector3 vector = new Vector3(Random.Range(FloorBoundary.leftBorder, FloorBoundary.rightBorder), obstaclePrefab.transform.position.y, spawnPosition);
        GameObject newObstacle = Instantiate(obstaclePrefab, vector, obstaclePrefab.transform.rotation);
        spawnPosition += Random.Range(minObstaclesSpacing, maxObstaclesSpacing) - Time.timeSinceLevelLoad / 500;
        activeObstacles.Add(newObstacle);
    }

    private void DestroyObstacle()
    {
        Destroy(activeObstacles[0]);
        activeObstacles.RemoveAt(0);
    }
}
