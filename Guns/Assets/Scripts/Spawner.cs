using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
        [SerializeField]
        private float timeToSpawn = 5f;
        private ObjectPool objectPool;
        [SerializeField]
        private GameObject prefab;
        [SerializeField] private int numberEnemy=10;
  
        private void Start()
        {
            objectPool = FindObjectOfType<ObjectPool>();
            StartCoroutine(SpawnEnemies());
        }

        IEnumerator SpawnEnemies()
        {
            while (true)
            {
                yield return new WaitForSeconds(timeToSpawn);
                GameObject newCritter = objectPool.GetObject(prefab);
            if (newCritter != null) {
                newCritter.transform.SetParent(transform);
                newCritter.transform.localPosition = new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f));
            }
              
        }
        }
 }
