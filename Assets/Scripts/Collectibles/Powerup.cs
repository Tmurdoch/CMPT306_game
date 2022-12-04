using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public AudioClip powerUpSound;
    [SerializeField] public Player player;

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player") {
            player = other.GetComponent<Player>();
            player.increaseSpeed();
            this.GetComponent<Renderer>().enabled = false;
            AudioSource.PlayClipAtPoint(powerUpSound, transform.position);
        }
    }

}
