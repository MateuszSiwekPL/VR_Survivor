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
        }
        else
        {
            Debug.Log("hit");
            anim.SetTrigger("Hit");
        }
    }
}
