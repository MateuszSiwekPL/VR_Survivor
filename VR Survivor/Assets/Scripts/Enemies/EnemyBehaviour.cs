using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [Header("Enemy values")]
    [SerializeField] float speed;
    [SerializeField] float hp;
    [SerializeField] float dmg;
    
    [Header("Animations")]
    [SerializeField] Animator anim;
    [SerializeField] GameObject shield;
    [SerializeField] ExplosionParticles explosionParticles;
    [SerializeField] float amountToWait;
    

    private void Awake() => explosionParticles = GameObject.Find("Enemies").GetComponent<ExplosionParticles>();   
    

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
            StartCoroutine(Explosion());
        }
        else
        {
            shield.SetActive(true);
            anim.SetTrigger("Hit");
        }
    }

    IEnumerator Explosion()
    {
        gameObject.transform.localScale = Vector3.zero;

        var expl = explosionParticles.Pooling();
        expl.transform.position = transform.position;
        expl.SetActive(true);

        yield return new WaitForSeconds(amountToWait);
        expl.SetActive(false);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider col) 
    {
        if(col.CompareTag("PlayerShield"))
        {
            col.GetComponent<ShieldBehaviour>().Hit(dmg);
            StartCoroutine(Explosion());
        }
    }

    public void DisableShield()
    {
        shield.SetActive(false);
    }
}
