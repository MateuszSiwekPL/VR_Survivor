using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehaviour : MonoBehaviour
{
    
    [SerializeField] float hp;
    [SerializeField] Animator animator;



    public void Hit(float dmg)
    {
        hp -= dmg;
        if(hp >= 0)
        {
            gameObject.SetActive(true);
            animator.SetTrigger("Hit");
        }
        else
        {
            Destroy(gameObject);
        }
    }




}
