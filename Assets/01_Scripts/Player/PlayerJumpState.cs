using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerStateBase
{
    // 플레이어 이동 유지용 리지드바디
    [SerializeField] private Rigidbody rb;

    // 점프시킬 플레이어 오브젝트
    [SerializeField] private GameObject player;

    // 레이캐스트 길이
    private float rayLength = 0.1f;
    
    // 점프 상태 확인
    private bool isJump = false;

    public override void Enter()
    {
        isJump = true;
        StartCoroutine(JumpPlayer());
    }

    public override void Execute(PlayerController controller)
    {
        
    }

    public override void Exit()
    {
        
    }

    public override void PhysicsUpdate()
    {
        if (isJump)
        {
            // 플레이어 아래로 레이캐스트 발사해서 지면에 착지했는지 체크
            RaycastHit hit;
            if (Physics.Raycast(rb.position, Vector3.down, out hit, 0.1f))
            {
                // 지면에 닿았다면
                if (hit.collider.CompareTag("Ground"))
                {
                    Debug.Log("Ground");
                    // 점프 상태에서 이동 상태로 변경
                    // controller.ChangeState(controller.pm);
                }
            }
        }
    }

    public IEnumerator JumpPlayer()
    {
        float jumpDuration = 1.0f;
        float gameSpeed = 1.0f;
        float baseHeight = 1.0f;
        float jumpHeight = 3.0f;

        if (player.transform.position.y < jumpHeight)
        {
            float jumpTime = 0.0f;
            while (jumpTime < jumpDuration)
            {
                jumpTime += Time.deltaTime * gameSpeed;
                float ratio = Mathf.Clamp01(jumpTime / jumpDuration);
                player.transform.position = new Vector3(player.transform.position.x, Mathf.Lerp(baseHeight, jumpHeight, ratio), player.transform.position.z);
            }
            Debug.Log("Jump");
        }

        yield return null;
    }
}
