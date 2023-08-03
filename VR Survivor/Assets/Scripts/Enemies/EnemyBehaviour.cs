using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [Header("Enemy values")]
    [SerializeField] float speed;
    [SerializeField] float hp;
    
    [Header("Animations")]
    [SerializeField] Animator anim;
    [SerializeField] GameObject shield;
    [SerializeField] GameObject explosion;


    



    private void Update() 
    {
        transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, speed);
        transform.LookAt(Vector3.zero);
        transform.rotation = Quaternion.Euler(15f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }


    public void Hit(float dmg)
    {
        hp -= dmg;
        if(hp <= 0)
        {
            gameObject.SetActive(false);
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
        else
        {
            shield.SetActive(true);
            anim.SetTrigger("Hit");
        }
    }

    public void DisableShield()
    {
        shield.SetActive(false);
    }
}
