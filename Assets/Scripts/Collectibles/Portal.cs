using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] public Player player;
    


    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player") {
            player = other.GetComponent<Player>();
            
            this.GetComponent<Renderer>().enabled = false;
            //TODO: sound
            
            //can't have reference to tileSpawner from prefab, so tell
            //player to do it
            player.nextEnvironment();
        }
    }
}
