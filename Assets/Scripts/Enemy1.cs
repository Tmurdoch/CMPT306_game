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

    void shoot() {
        var projectile = Instantiate(bulletPrefab, transform.position, transform.rotation);
        // projectile.velocity = transform.forward * shootSpeed;
    }
}
