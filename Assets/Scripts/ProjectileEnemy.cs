using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProjectileEnemy : MonoBehaviour
{
    [SerializeField] private float lifeTime = 5.0f;   
   [SerializeField] private float moveSpeed = 5.0f; 
   [SerializeField] private float damage = 50.0f; 

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, lifeTime); 
    }

    void OnTriggerEnter(Collider other) {
        if (other.transform.tag == "Player") {
            other.GetComponent<Player>().TakeDamage(damage); 
            Destroy(this.gameObject); 
        }
    }
}
