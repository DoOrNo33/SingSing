using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectionObject : MonoBehaviour
{
    //[SerializeField] private PlayerMovement pm;

    //// 팅겨내는 힘의 세기
    //[SerializeField] private float reflectionPower = 10f;

    //// 3D 콜라이더
    //[SerializeField] private Collider col;

    //// 리지드바디 테스트용
    //[SerializeField] private Rigidbody playerRb;

    //// 충돌이 일어났을 때 호출되는 함수
    //private void OnCollisionEnter(Collision other)
    //{
    //    // 충돌한 오브젝트의 레이어가 Player인 경우
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        // 플레이어의 이동을 멈춤
    //        // pm.IsReflection = true;

    //        // 팅겨내는 방향을 계산

    //        playerRb = other.gameObject.GetComponent<PlayerCol>().PlayerRb;
    //        if (playerRb != null)
    //        {
    //            // 팅겨내는 방향을 계산
    //            Vector3 playerVelocity = playerRb.velocity;
    //            Vector3 reflectionDir = -playerVelocity.normalized;

    //            // 팅겨내는 힘을 가함
    //            playerRb.AddForce(reflectionDir * reflectionPower, ForceMode.Impulse);
    //        }
    //        else
    //        {
    //            Debug.LogError("PlayerRb is not assigned in PlayerCol component.");
    //        }
    //    }
    //    else
    //    {
    //        Debug.LogError("PlayerCol component is not found on the Player object.");
    //    }
    //}
}
