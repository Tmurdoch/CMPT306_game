using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{
    private float collisionDamage = 10.0f;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            other.GetComponent<Player>().TakeDamage(collisionDamage);
        }
    }
}
