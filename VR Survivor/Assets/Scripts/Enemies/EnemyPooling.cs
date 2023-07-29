using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooling : MonoBehaviour
{
    [Header("Pooling")]
    [SerializeField] GameObject enemy;
    [SerializeField] List<GameObject> enemiesList = new List<GameObject>();
    [SerializeField] int numberOfEnemies;
    [SerializeField] Transform parent;



    private void Awake() 
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            var obj = Instantiate(enemy, parent);
            obj.SetActive(false);
            enemiesList.Add(obj);
        }   
    }

    public GameObject Pooling()
    {
        for (int i = 0; i < enemiesList.Count; i++)
        {
            if(!enemiesList[i].activeInHierarchy)
            return enemiesList[i];
        }
        return null;
    }

}
