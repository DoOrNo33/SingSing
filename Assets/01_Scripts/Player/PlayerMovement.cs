using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 12f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float reflectionPower = 100f;
    [SerializeField] private float dragDuringReflection = 10f;
    private bool isReflection = false;
    
    public bool IsReflection
    {
        get => isReflection;
        set => isReflection = value;
    }

    // 캐릭터 컨트롤러를 이용해서 플레이어가 특별한 조작 없이는 계속 앞으로 움직임
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
        //else
        //{
        //    rb.velocity = Vector3.zero;  // 반사 중일 때는 속도를 0으로 설정
        //}
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
