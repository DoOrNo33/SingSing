using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Grid
{
    private int width;
    private int height;
    private float cellSize;
    private Vector3 originPosition;
    private int fontSize = 20;
    private int[,] gridArray;
    private TextMesh[,] debugTextArray;

    public Grid(int width, int height, float cellSize, Vector3 originPosition)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;

        gridArray = new int[width, height];
        debugTextArray = new TextMesh[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int z = 0; z < gridArray.GetLength(1); z++)
            {
                debugTextArray[x, z] = UtilsClass.CreateWorldText(gridArray[x, z].ToString(), null, GetWorldPosition(x, z) + new Vector3(cellSize, 0, cellSize) * .5f, fontSize, Color.white, TextAnchor.MiddleCenter);

                Debug.DrawLine(GetWorldPosition(x, z), GetWorldPosition(x, z + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, z), GetWorldPosition(x + 1, z), Color.white, 100f);
            }
        }

        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
    }

    private Vector3 GetWorldPosition(int x, int z)
    {
        return new Vector3(x, 0, z) * cellSize + originPosition;
    }

    // 좌표값 가져옴
    private void GetXZ(Vector3 worldPosition, out int x, out int z)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        z = Mathf.FloorToInt((worldPosition - originPosition).z / cellSize);
    }

    public void SetValue(int x, int z, int value)
    {
        if (x >= 0 && z >= 0 && x < width && z < height)
        {
            gridArray[x, z] = value;
            debugTextArray[x, z].text = gridArray[x, z].ToString();
        }
    }

    public void SetValue(Vector3 worldPosition, int value)
    {
        int x;
        int z;
        GetXZ(worldPosition, out x, out z);
        SetValue(x, z, value);
    }

    // 장애물 제작용 그리드 포지션 반환
    public Vector3 GetPosition(Vector3 worldPosition)
    {
        int x;
        int z;
        GetXZ(worldPosition, out x, out z);
        // 그리드 좌표에 해당하는 월드 좌표 반환
        return new Vector3 (x, 0, z) * cellSize + originPosition;
    }

    public void GetGridPosition(Vector3 worldPosition, out int x, out int z)
    {
        GetXZ(worldPosition, out x, out z);
    }
}