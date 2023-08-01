using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    [Header("Spawning")]
    [SerializeField] EnemyPooling enemyPooling;
    [SerializeField] float timeBetweenSpawn;
    [SerializeField] float radious;


    private void Start() 
    {
        StartCoroutine(Gameplay());
    }

    private Vector3 Positioning()
    {
        Vector3 randomPosition = Random.insideUnitSphere;
        Vector3 positionToSpawn = randomPosition.normalized * radious;
        return positionToSpawn;
    }

    IEnumerator Spawning(int enemiesToSpawn, int stage)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            var obj = enemyPooling.Pooling(stage);
            obj.transform.position = Positioning();
            obj.SetActive(true);

            yield return new WaitForSeconds(timeBetweenSpawn);
        }
    }

    IEnumerator Gameplay()
    {
        for (int i = 1; i <= 6; i++)
        {
            StartCoroutine(Spawning(i*2, 0));
            yield return new WaitForSeconds(i*5);
        }
        

    }

}
