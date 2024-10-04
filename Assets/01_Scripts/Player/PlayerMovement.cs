using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 12f;
    [SerializeField] private Rigidbody rb;
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
            Vector3 newPosition = rb.position + Vector3.forward * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(newPosition);
        }
    }

}
