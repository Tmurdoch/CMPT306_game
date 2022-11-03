using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{

    public Rigidbody bulletPrefab;
    public float shootSpeed = 150;

    private float fireRate = 0.5f; //fired a second
    private Transform player = null;

    private bool playerInRange = false;

    void OnTriggerEnter(Collider other) {
        Debug.Log("entered ranged");
        if (other.tag == "player") {
            playerInRange = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
