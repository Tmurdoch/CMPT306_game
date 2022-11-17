using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    [SerializeField] private float spawnRate = 2.0f;
    private float spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        int randomNess = Random.Range(1, 4);
        for(int i = 0; i < randomNess; i++)
        {
            StartCoroutine(SpawnEnemy());
        }
    }


    IEnumerator SpawnEnemy() {
        yield return new WaitForSeconds(Random.Range(1,6));
        Instantiate(Enemy, transform.position, transform.rotation);
        spawnTimer = Time.time + spawnRate;
    }

    void Update() {
        Transform target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
         Vector3 toTarget = (target.position - transform.position).normalized;
            if (Vector3.Dot(toTarget, transform.forward) > 0) {
                Destroy(this);
            }
    }
}
