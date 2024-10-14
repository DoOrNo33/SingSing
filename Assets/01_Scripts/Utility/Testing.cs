using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Testing : MonoBehaviour
{
    private Grid grid;
    private void Start()
    {
        grid = new Grid(4, 2, 10f, new Vector3(20, 0));
    }

    // private void Update()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         Vector3? hitPoint = GetMouseWorldPositionOnPlane();
    //         // grid.SetValue(UtilsClass.GetMouseWorldPosition(), 56);
    //         grid.SetValue(hitPoint.Value, 56);
    //     }
    // }

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
