using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
        public GameObject enemyWhitePrefab;
        public GameObject enemyRedPrefab;
        public float spawnDelay = 1f;

        private void Start()
        {
            StartCoroutine(SpawnEnemies());
        }

        IEnumerator SpawnEnemies()
        {
            while (true)
            {
                yield return new WaitForSeconds(spawnDelay);
            int randomIndex = Random.Range(0, 2);
            GameObject prefabToSpawn = randomIndex == 0 ? enemyWhitePrefab : enemyRedPrefab;

            GameObject newObject=Instantiate(prefabToSpawn,transform);
            newObject.transform.localPosition = Vector3.zero;
            }
        }
 }
