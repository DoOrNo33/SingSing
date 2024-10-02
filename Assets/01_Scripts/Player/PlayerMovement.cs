using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float moveSpeed = 12f;
    private bool isReflection = false;

    // 캐릭터 컨트롤러를 이용해서 플레이어가 특별한 조작 없이는 계속 앞으로 움직임
    private void FixedUpdate()
    {
        MovePlayer();
    }
    
    private void MovePlayer()
    {
        if (!IsReflection)
        {
           characterController.Move(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }

    public bool IsReflection
    {
        get => isReflection;
        set => isReflection = value;
    }
}
