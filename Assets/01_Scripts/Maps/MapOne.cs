using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapOne : Maps
{
    // Null,
    // Trap,
    // Score,
    // Reflection,
    // Coin

    public int[,] mapSave = new int[3, 3]
    {
        {0, 1, 1},
        {1, 2, 2},
        {3, 2, 2}
    };

    public override int[,] mapLoad()
    {
        // 두 번째 인트 값을 역순으로 저장해서 리턴
        for (int x = 0; x < mapSave.GetLength(0); x++)
        {
            for (int z = 0; z < mapSave.GetLength(1) / 2; z++)
            {
                int temp = mapSave[x, z];
                mapSave[x, z] = mapSave[x, mapSave.GetLength(1) - 1 - z];
                mapSave[x, mapSave.GetLength(1) - 1 - z] = temp;
            }
        }

        return mapSave;
    }
}
