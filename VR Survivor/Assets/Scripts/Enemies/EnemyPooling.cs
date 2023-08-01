using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooling : MonoBehaviour
{
    [Header("Pooling")]
    [SerializeField] GameObject[] enemy;
    [SerializeField] List<GameObject> enemiesList = new List<GameObject>();
    [SerializeField] int numberOfEnemies;
    [SerializeField] Transform parent;



    private void Awake() 
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < numberOfEnemies; j++)
            {
                var obj = Instantiate(enemy[i], parent);
                obj.SetActive(false);
                enemiesList.Add(obj);
            } 
        }
    }

    public GameObject Pooling(int stage)
    {
        for (int i = stage * numberOfEnemies; i < (stage+1) * numberOfEnemies; i++)
        {
            if(!enemiesList[i].activeInHierarchy)
            return enemiesList[i];
        }
        return null;
    }

}
