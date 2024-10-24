using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    private List<Maps> maps = new List<Maps>();

    [SerializeField] private GameObject[] obstaclePrefabs;

    [Header("Grid")]
    private Grid grid;
    [SerializeField] private int gridWidth = 100;
    [SerializeField] private int gridHeight = 100;
    [SerializeField] private float gridCellSize = 10f;
    [SerializeField] private float gridOriginX = -500;
    [SerializeField] private float gridOriginZ = -500;

    void Awake()
    {
        // 그리드 생성
        grid = new Grid(gridWidth, gridHeight, gridCellSize, new Vector3(gridOriginX, 0, gridOriginZ));

        maps.Add(new MapOne());
    }

    void Start()
    {
        GenerateMap(0);
    }

    private void GenerateMap(int index)
    {
        Maps map = maps[index];
        int[,] mapSave = map.mapLoad();

        for (int x = 0; x < mapSave.GetLength(0); x++)
        {
            for (int z = 0; z < mapSave.GetLength(1) ; z++)
            {
                int obstacleIndex = mapSave[x, z];
                if (obstacleIndex != 0)
                {
                    Vector3 pos = grid.GetWorldPosition(x, z) + new Vector3(0, 1, 0);
                    Instantiate(obstaclePrefabs[obstacleIndex], pos, Quaternion.identity);
                }
            }
        }
    }


}
