using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectionObject : MonoBehaviour
{
    [SerializeField] private PlayerMovement pm;

    // 팅겨내는 힘의 세기
    [SerializeField] private float reflectionPower = 10f;

    // 팅겨내는 방향
    private Vector3 reflectionDir;

    // 3D 콜라이더
    [SerializeField] private Collider col;

    // 팅겨내는 힘을 가하는 함수


    // 충돌이 일어났을 때 호출되는 함수
    private void OnCollisionEnter(Collision other)
    {
        // 충돌한 오브젝트의 레이어가 Player인 경우
        if (other.gameObject.CompareTag("Player"))
        {
            // 플레이어의 이동을 멈춤
            pm.IsReflection = true;

            // 팅겨내는 방향을 계산
            reflectionDir = (other.transform.position - transform.position).normalized;

            // 팅겨내는 힘을 가함
            CharacterController cc = other.gameObject.GetComponent<CharacterController>();
            if (cc != null)
            {
                Vector3 force = reflectionDir * reflectionPower;
                StartCoroutine(ApplyForce(cc, force));
            }
        }
    }

    private IEnumerator ApplyForce(CharacterController cc, Vector3 force)
    {
        float duration = 0.2f; // 0.2초 동안 힘을 가함
        float elapsedTime = 0f; // 경과 시간
        Vector3 originalVelocity = cc.velocity; // 기존 이동 벡터 저장

        while (elapsedTime < duration)
        {
            cc.Move(force * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        cc.Move(originalVelocity * Time.deltaTime); // 기존 이동 벡터 복원
        pm.IsReflection = false; // 플레이어 이동 재개
    }
}
