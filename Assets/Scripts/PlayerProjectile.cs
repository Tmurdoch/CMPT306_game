using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] private float life = 5.0f;
    [SerializeField] private float movementSpeed = 300.0f;
    [SerializeField] private float Damage = 50.0f; 

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, life);
    }

    // Update is called once per frame
    void Update()
    {
        MoveProjectiles();
    }

    private void MoveProjectiles() {
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }

        void OnTriggerEnter(Collider other) {
        if (other.transform.tag == "Enemy") {
            other.GetComponent<Enemy1>().TakeDamage(Damage); 
            Destroy(this.gameObject); 
        }
    }
}
