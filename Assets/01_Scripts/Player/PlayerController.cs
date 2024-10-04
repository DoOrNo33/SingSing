using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Enums;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMovement pm;

    public void TurnLeft()
    {
        pm.SetDirection((int)ControllerButton.left);
    }

    public void TurnRight()
    {
        pm.SetDirection((int)ControllerButton.right);
    }
}
