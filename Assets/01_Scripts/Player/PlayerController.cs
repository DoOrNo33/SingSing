using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enums;

public class PlayerController : MonoBehaviour
{
    public PlayerMovement pm;

    public void TurnLeft()
    {
        pm.SetDirection((int)ControllerButton.left);
    }

    public void TurnRight()
    {
        pm.SetDirection((int)ControllerButton.right);
    }

    ////////////////////////////////
    private PlayerStateBase currentState = null;

    public PlayerJumpState pjs;
    


    private void Start()
    {
        // 초기 상태 설정
        ChangeState(pm);
    }

    private void Update()
    {
        currentState?.Execute(this);
    }

    private void FixedUpdate()
    {
        currentState?.PhysicsUpdate();
    }

    // 상태 변경 시 호출
    public void ChangeState(PlayerStateBase newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
    }
}
