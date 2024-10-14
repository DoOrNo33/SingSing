using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapObj : MonoBehaviour
{
    public int Type = (int)Enums.ObstacleType.Trap;

    public void Trap()
    {
        // 트랩 발동
        // GameManager.Instance.GameOver();
        Debug.Log("트랩 발동!");
    }
}
