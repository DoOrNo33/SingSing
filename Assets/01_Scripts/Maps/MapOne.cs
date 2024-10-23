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
        return mapSave;
    }
}
