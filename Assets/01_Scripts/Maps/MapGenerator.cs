using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    private List<Maps> maps = new List<Maps>();

    [SerializeField] private GameObject[] obstaclePrefabs;

    void Awake()
    {
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
            for (int z = 0; z < mapSave.GetLength(1); z++)
            {
                int obstacleIndex = mapSave[x, z];
                if (obstacleIndex != 0)
                {
                    Vector3 pos = new Vector3(x, 1, z);
                    Instantiate(obstaclePrefabs[obstacleIndex], pos, Quaternion.identity);
                }
            }
        }
    }


}
