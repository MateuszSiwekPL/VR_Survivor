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
        StartCoroutine(Spawning(20));
    }

    private Vector3 Positioning()
    {
        Vector3 randomPosition = Random.insideUnitSphere;
        Vector3 positionToSpawn = randomPosition.normalized * radious;
        return positionToSpawn;
    }

    IEnumerator Spawning(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            var obj = enemyPooling.Pooling();
            obj.transform.position = Positioning();
            obj.SetActive(true);

            yield return new WaitForSeconds(timeBetweenSpawn);
        }
    }



}
