using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [Header("Move values")]
    [SerializeField] float speed;



    private void Update() 
    {
        transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, speed);
    }
}
