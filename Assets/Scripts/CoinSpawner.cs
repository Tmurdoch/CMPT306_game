using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject Coin;
    [SerializeField] private float spawnRate = 2.0f;
    private float spawnTimer;
    // Start is called before the first frame update
    void SpawnCoin()
    {
        Instantiate(Coin, new Vector3(Random.Range(-9,9),1,transform.position.z), transform.rotation);
        spawnTimer = Time.time + spawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        Transform target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Vector3 toTarget = (target.position - transform.position).normalized;
        if (Time.time > spawnTimer) {
            SpawnCoin();
            spawnRate -= 0.000001f;
        }
    }
    public void setSpawnRate(float rate) {
            spawnRate = rate;
    }
}
