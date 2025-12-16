using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject floorPrefab;
    public Transform player;

    [Header("720x1280 고정 수치")]
    // 카메라 Size 5일 때, 가로 전체 너비는 약 5.6유닛입니다.
    // 이를 3등분하면 각 칸의 중심은 -1.87, 0, 1.87이 됩니다.
    private float laneDistance = 1.87f;

    public float floorGapY = 2.0f;
    public float generationThreshold = 15f;

    private float currentFloorY = 0f;

    void Start()
    {
        // 중요: 생성기의 위치를 무조건 0으로 초기화
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

        // 0, 1, 2번 중 구멍이 될 인덱스 하나 선택
        int holeIndex = Random.Range(0, 3);

        for (int i = 0; i < 3; i++)
        {
            // 구멍 자리는 생성하지 않음
            if (i == holeIndex) continue;

            // 좌표 계산: -1.87, 0, 1.87 위치에 박음
            float xPos = (i - 1) * laneDistance;
            Vector3 spawnPos = new Vector3(xPos, currentFloorY, 0f);

            GameObject floor = Instantiate(floorPrefab, spawnPos, Quaternion.identity, transform);

            // 발판 프리팹의 가로 크기를 칸 너비에 맞게 강제 조정 (틈새 제거)
            floor.transform.localScale = new Vector3(laneDistance, floor.transform.localScale.y, 1f);
        }
    }
}