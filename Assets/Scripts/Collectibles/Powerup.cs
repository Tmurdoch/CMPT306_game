using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    void onTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player") {
        Debug.Log("Collision");
        other.GetComponent<Player>().increaseSpeed();
        Destroy(gameObject);
        }
    }
}
