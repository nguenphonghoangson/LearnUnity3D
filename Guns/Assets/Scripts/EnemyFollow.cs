    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.AI;

    public class EnemyFollow : MonoBehaviour,IDamageable
    {
        public NavMeshAgent enemy;
        public GameObject player;
        public GameObject obj;
        public float health;
        // Start is called before the first frame update
        void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player");
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
            if (health <= 0) Destroy(gameObject);
        }
    }
