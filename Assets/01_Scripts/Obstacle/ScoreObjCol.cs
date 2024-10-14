using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObjCol : MonoBehaviour
{
    [SerializeField] private ScoreObj scoreObj;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            scoreObj.AddScore();
        }
    }
}
