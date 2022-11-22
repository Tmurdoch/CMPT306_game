using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{
    private float collisionDamage = 10.0f;
    private Shake shake = null;
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            other.GetComponent<Player>().TakeDamage(collisionDamage);
            shake.start = true;
        }
    }

    void Start() {
        shake = GameObject.Find("Shake").GetComponent<Shake>();
    }
}
