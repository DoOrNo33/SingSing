using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] private Grid grid;

    [SerializeField] private GameObject[] obstaclePrefabs;
    [SerializeField] private int obstacleIndex = 0;

    private void Update()
    {
        // 마우스 좌클릭으로 장애물 생성
        if (Input.GetMouseButtonDown(0))
        {
            Vector3? hitPoint = GetMouseWorldPositionOnPlane();
            Vector3 pos = grid.GetPosition(hitPoint.Value);

            Instantiate(obstaclePrefabs[obstacleIndex], pos, Quaternion.identity);
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
