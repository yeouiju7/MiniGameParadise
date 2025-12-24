using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject floorPrefab;
    public Transform player;

    private float laneDistance = 1.875f;
    public float floorGapY = 2.0f;
    public float generationThreshold = 15f;
    private float currentFloorY = 0f;

    void Start()
    {
        transform.position = Vector3.zero;
        currentFloorY = player.position.y - 3f;

        for (int i = 0; i < 15; i++)
        {
            GenerateRow();
        }
    }

    void Update()
    {
        if (player.position.y - generationThreshold < currentFloorY)
        {
            GenerateRow();
        }
    }

    void GenerateRow()
    {
        currentFloorY -= floorGapY;
        int holeIndex = Random.Range(0, 3);

        for (int i = 0; i < 3; i++)
        {
            if (i == holeIndex) continue;

            float xPos = (i - 1) * laneDistance;
            Vector3 spawnPos = new Vector3(xPos, currentFloorY, 0f);
            GameObject floor = Instantiate(floorPrefab, spawnPos, Quaternion.identity, transform);

            floor.transform.localScale = new Vector3(laneDistance, floor.transform.localScale.y, 1f);
        }
    }
}