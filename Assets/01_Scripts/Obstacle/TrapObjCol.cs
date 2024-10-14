using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapObjCol : MonoBehaviour
{
    [SerializeField] private TrapObj trapObj;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            trapObj.Trap();
        }
    }
}
