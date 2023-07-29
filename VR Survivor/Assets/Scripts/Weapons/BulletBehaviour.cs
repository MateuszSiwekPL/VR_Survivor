using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] float speed;
    
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider col) 
    {
        if (col.CompareTag("Enemy"))
        {
            Debug.Log("hit");
            Destroy(col.gameObject);
        }
    
    }
}
