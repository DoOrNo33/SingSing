using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] private PlayerMovement pm;
    [SerializeField] private Rigidbody playerRb;
    [SerializeField] private float reflectionPower;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ReflectionObj"))
        {
            // 충돌 시 playerRb가 null이 아니라면,
            if (playerRb != null)
            {
                //pm.IsReflection = true;

                // 진행 방향 반대로 밀어낸다.
                Vector3 playerDir = playerRb.velocity;
                Vector3 reflectionDir = -playerDir.normalized;
                //playerRb.AddForce(reflectionDir * reflectionPower, ForceMode.Impulse);
                pm.ReflectPlayer(reflectionDir);
            }
        }
    }
}
