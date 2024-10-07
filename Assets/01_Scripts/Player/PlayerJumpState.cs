using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerStateBase
{
    [SerializeField] private Rigidbody rb;

    public override void Enter()
    {
        
    }

    public override void Execute(PlayerController controller)
    {
        
    }

    public override void Exit()
    {
        
    }

    public override void PhysicsUpdate()
    {
        // 플레이어 아래로 레이캐스트 발사해서 지면에 착지했는지 체크
        RaycastHit hit;
        if (Physics.Raycast(rb.position, Vector3.down, out hit, 0.5f))
        {
            // 지면에 닿았다면
            if (hit.collider.CompareTag("Ground"))
            {
                // 점프 상태에서 이동 상태로 변경
                // controller.ChangeState(controller.pm);
            }
        }
    }
}
