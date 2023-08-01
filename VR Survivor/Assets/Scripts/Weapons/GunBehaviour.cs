using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] float shootingSpeed;
    [SerializeField] List<GameObject> bulletList = new List<GameObject>();
    [SerializeField] int numberOfBullets;
    [SerializeField] Transform parent;
    PlayerControls controlls;
    [SerializeField] string hand;

    private void Awake() 
    {
        controlls = new PlayerControls();
        SpawningBullets();
        StartCoroutine(Shooting());
    }


    private void SpawningBullets()
    {
        for (int i = 0; i < numberOfBullets; i++)
        {
            var obj = Instantiate(bullet, parent);
            obj.SetActive(false);
            bulletList.Add(obj);
        }
    }

    private GameObject Pooling()
    {
        for (int i = 0; i < bulletList.Count; i++)
        {
            if(!bulletList[i].activeInHierarchy)
            return bulletList[i];
        }
        return null;
    }

    IEnumerator Shooting()
    {
        while(true)
        {
            if((controlls.Shooting.Left.IsPressed() && hand == "Left") || (controlls.Shooting.Right.IsPressed() && hand == "Right"))
            {
                var obj = Pooling();
                obj.SetActive(true);
                obj.transform.position = transform.position;
                obj.transform.rotation = transform.rotation;

                yield return new WaitForSeconds(shootingSpeed);
            }

            yield return null;
        }
    }


    private void OnEnable() => controlls.Enable();
    private void OnDisable() => controlls.Disable();
}
