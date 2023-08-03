using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionParticles : MonoBehaviour
{
   [SerializeField] GameObject explosion;
   [SerializeField] int amountToSpawn;
   [SerializeField] List<GameObject> explosions = new List<GameObject>();
   [SerializeField] Transform parent;


   private void Awake() 
   {
        for (int i = 0; i < amountToSpawn; i++)
        {
            var obj = Instantiate(explosion, parent);
            obj.SetActive(false);
            explosions.Add(obj);
        }
   }


   public GameObject Pooling()
   {
        for (int i = 0; i < explosions.Count; i++)
        {
            if(!explosions[i].activeInHierarchy)
            return explosions[i];
        }
        return null;
   }

}
