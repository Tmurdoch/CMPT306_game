using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    [SerializeField] private float spawnRate = 3.0f;
    private float spawnTimer;


    void SpawnEnemy() {
        Instantiate(Enemy, new Vector3(Random.Range(-9, 9), 1, transform.position.z), transform.rotation);
        spawnTimer = Time.time + spawnRate;
    }

    void Update() {
        Transform target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Vector3 toTarget = (target.position - transform.position).normalized;
       

        if (Time.time > spawnTimer) {
            SpawnEnemy();
            spawnRate -= 0.00000001f;
        }
        
    }

    public void setSpawnRate(float rate) {
        spawnRate = rate;
    }
}
