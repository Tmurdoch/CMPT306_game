using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float moveSpeed = 1.0f;

    public GameObject bulletPrefab;
    public float shootSpeed = 0.5f;

    private float fireRate = 0.5f; //fired a second
    private float lastAttackTime = 0f;
    private Transform player = null;

    private bool playerInRange = false;

    private float enemyHealth = 100.0f;

    void OnTriggerEnter(Collider other) {
        Debug.Log("entered ranged");
        if (other.tag == "Player") {
            player = other.transform;
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            playerInRange = false;
            player = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        if (playerInRange) {

            transform.rotation = Quaternion.LookRotation(player.position - transform.position, transform.up);

            if (Time.time - lastAttackTime >= 1f / fireRate)  {
                shoot();
                lastAttackTime = Time.time;
            }

        }
    }

    public void TakeDamage (float damage) {
    enemyHealth -= damage; 

    if (enemyHealth <= 0) {

        Debug.Log("should take damage");
        //GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
        //Destroy(effect, 1.0f); 
        Destroy(this.gameObject);     
    }
    }

    void shoot() {
        var projectile = Instantiate(bulletPrefab, transform.position, transform.rotation);
        // projectile.velocity = transform.forward * shootSpeed;
    }
}
