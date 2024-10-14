using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObj : MonoBehaviour
{
    public int Type = (int)Enums.ObstacleType.Score;
    [SerializeField] private int score = 1;

    public void AddScore()
    {
        // 점수 추가
        // GameManager.Instance.AddScroe(score);
        Debug.Log("점수 획득!");

        // 오브젝트 삭제
        Destroy(gameObject);
    }
}
