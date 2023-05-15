    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.AI;
using UnityEngine.Pool;

    public class EnemyFollow : MonoBehaviour,IDamageable
    {
        public NavMeshAgent enemy;
        private GameObject player;
        private GameObject obj;
        public float health;
        private ObjectPool objectPool;

    // Start is called before the first frame update
    void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            objectPool = FindObjectOfType<ObjectPool>();
        }

        // Update is called once per frame
        void Update()
        {

        enemy.SetDestination(player.transform.position);
        }

        public void TakeDamage(float damage)
        {
            health -= damage;
            Debug.Log(health);
        if (health <= 0) {
            objectPool.ReturnGameObject(gameObject);
            player.GetComponent<PlayerController>().EnemyDie++;
        };
        }
}
