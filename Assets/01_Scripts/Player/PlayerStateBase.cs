using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerStateBase : MonoBehaviour
{
    public abstract void Enter();

    public abstract void Execute(PlayerController controller);

    public abstract void PhysicsUpdate();

    public abstract void Exit();
}
