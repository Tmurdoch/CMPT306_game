using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 1.0f;

    public GameObject bulletPrefab;
    public float shootSpeed = 0.5f;

    private float fireRate = 0.5f; //fired a second
    private float lastAttackTime = 0f;
    private Transform player = null;

    private bool playerInRange = false;

    private float enemyHealth = 100.0f;

    private float collisionDamage = 10.0f;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            other.GetComponent<Player>().TakeDamage(collisionDamage); 
        }
    }

    void OnTriggerExit(Collider other) {
    }

    void Start() {
       player = GameObject.FindWithTag("Player").transform;
       Debug.Log(player);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        if (player) {
            float dist = Vector3.Distance(player.position, transform.position);
            if(dist <= 18) {
            transform.LookAt(player);
            // transform.rotation = Quaternion.LookRotation(transform.position - transform.position, transform.up);
            if (Time.time - lastAttackTime >= 1f / fireRate)  {
                shoot();
                lastAttackTime = Time.time;
             }
            }
        }
    }

    public void TakeDamage (float damage) {
        enemyHealth -= damage; 
        Debug.Log("enemy health now:" + enemyHealth);
        if (enemyHealth <= 0) {
                //GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
                //Destroy(effect, 1.0f); 
                Destroy(this.gameObject);
                Debug.Log("enemy should be destroyed" + this.gameObject);
            }
    }

    void shoot() {
        var projectile = Instantiate(bulletPrefab, transform.position, transform.rotation);
        // projectile.velocity = transform.forward * shootSpeed;
    }
}
