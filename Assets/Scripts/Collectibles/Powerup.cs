using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    void onTriggerEnter(Collider other)
    {
        other.GetComponent<Player>().increaseSpeed();
        Destroy(gameObject);
    }
}
