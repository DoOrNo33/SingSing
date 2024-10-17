using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    // 그리드 시스템
    private Grid grid;

    [Header("Grid")]
    [SerializeField] private int gridWidth = 10;
    [SerializeField] private int gridHeight = 10;
    [SerializeField] private float gridCellSize = 10f;
    [SerializeField] private float gridOriginX = -50;
    [SerializeField] private float gridOriginZ = -50;

    [Header("Obstacle")]
    [SerializeField] private GameObject[] obstaclePrefabs;
    [SerializeField] private int obstacleIndex = 0;
    private Vector3 obstaclePos = new Vector3 (0, 1, 0);

    [Header("Save")]
    private int[,] mapSave;

    private void Start() 
    {
        grid = new Grid(gridWidth, gridHeight, gridCellSize, new Vector3(gridOriginX, 0, gridOriginZ));

        // 맵 저장용 배열 생성
        mapSave = new int[gridWidth, gridHeight];
    }

    private void Update()
    {
        // 마우스 좌클릭으로 장애물 생성
        if (Input.GetMouseButtonDown(0))
        {
            Vector3? hitPoint = GetMouseWorldPositionOnPlane();
            Vector3 pos = grid.GetPosition(hitPoint.Value);
            Instantiate(obstaclePrefabs[obstacleIndex], pos + obstaclePos, Quaternion.identity);

            // 맵 저장용 배열에 장애물 위치 저장
            grid.GetGridPosition(hitPoint.Value, out int x, out int z);
            mapSave[x, z] = obstacleIndex;
            Debug.Log("Obstacle Index: " + obstacleIndex);
        }

        // 마우스 우클릭으로 장애물 종류 변경
        if (Input.GetMouseButtonDown(1))
        {
        obstacleIndex = (obstacleIndex + 1) % obstaclePrefabs.Length;
        Debug.Log("Obstacle Index: " + obstacleIndex);
        }
    }

        // 장애물 생성을 위한 좌표값 가져옴
    private Vector3? GetMouseWorldPositionOnPlane()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        int planeLayerMask = LayerMask.GetMask("Plane");

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, planeLayerMask))
        {
            return hit.point;
        }
        else
        {
            return null;
        }
    }
}
