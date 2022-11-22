using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] public Player player = null;

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player") {
            player = other.GetComponent<Player>();
            player.increaseSpeed();
            this.GetComponent<Renderer>().enabled = false;
            Invoke(nameof(ResetEffect), 10.0f);
        }
    }

    void ResetEffect() {
        player.decreaseSpeed();
        Destroy(this);
    }

}
