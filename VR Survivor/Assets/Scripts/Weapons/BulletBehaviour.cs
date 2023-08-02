using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] float speed;

    [SerializeField] float dmg;
    
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider col) 
    {
        if (col.CompareTag("Enemy"))
        {
            col.GetComponent<EnemyBehaviour>().Hit(dmg);
            gameObject.SetActive(false);
        }
    
    }
}
