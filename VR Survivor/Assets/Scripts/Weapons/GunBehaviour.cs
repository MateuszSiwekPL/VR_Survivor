using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : MonoBehaviour
{


    [SerializeField] GameObject bullet;
    [SerializeField] float shootingSpeed;
    private void Awake() 
    {
        StartCoroutine(Shooting());
    }

    IEnumerator Shooting()
    {
        while(true)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            yield return new WaitForSeconds(shootingSpeed);
        }
    }
}
