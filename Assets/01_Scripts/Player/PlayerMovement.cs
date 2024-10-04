using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 12f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float reflectionPower = 100f;
    [SerializeField] private float dragDuringReflection = 10f;
    private Vector3[] directions = 
        { Vector3.forward,
        Vector3.right,
        Vector3.back,
        Vector3.left
        };
    private Vector3 playerDir;
    
    private bool isReflection = false;
    
    public bool IsReflection
    {
        get => isReflection;
        set => isReflection = value;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
    
    private void MovePlayer()
    {
        if (!IsReflection)
        {
            rb.velocity = Vector3.forward * moveSpeed;
        }
    }

    public void ReflectPlayer(Vector3 reflectionDir)
    {
        if (rb != null)
        {
            isReflection = true;
            rb.drag = dragDuringReflection; // 반사 중일 때 드래그 적용
            rb.AddForce(reflectionDir * reflectionPower, ForceMode.Impulse);
            StartCoroutine(ResetReflection());
        }
    }

    private IEnumerator ResetReflection()
    {
        yield return new WaitForSeconds(0.5f); // 반사 후 0.5초 동안 이동 멈춤

        rb.drag = 0; // 드래그 초기화
        isReflection = false;
    }
}
