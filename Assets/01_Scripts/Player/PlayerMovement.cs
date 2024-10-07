using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PlayerMoveBase
{
    [SerializeField] private float moveSpeed = 12f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float reflectionPower = 100f;
    [SerializeField] private float dragDuringReflection = 10f;

    // 플레이어 이동 방향
    private Vector3[] directions = 
        { Vector3.forward,
        Vector3.right,
        Vector3.back,
        Vector3.left
        };
    private int dirIndex = 0;
    private Vector3 playerDir;
    
    private bool isReflection = false;
    
    public bool IsReflection
    {
        get => isReflection;
        set => isReflection = value;
    }

    private void Start()
    {
        playerDir = directions[dirIndex];
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
    
    private void MovePlayer()
    {
        if (!IsReflection)
        {
            rb.velocity = playerDir * moveSpeed;
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

    public void SetDirection(int dir)
    {
        dirIndex += dir;

        // dirIndex가 최대값을 초과하면 최소값으로 초기화
        if (dirIndex >= directions.Length)
        {
            dirIndex = 0;
        }
        // dirIndex가 최소값보다 작다면 최대값으로 초기화
        if (dirIndex < 0)
        {
            dirIndex = (directions.Length - 1);
        }


        playerDir = directions[dirIndex];
    }

    public override void Enter()
    {

    }

    public override void Execute(PlayerController controller)
    {

    }

    public override void PhysicsUpdate()
    {

    }

    public override void Exit()
    {

    }
}
