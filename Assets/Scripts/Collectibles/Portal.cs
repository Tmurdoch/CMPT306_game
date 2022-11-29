using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] public Player player;
    [SerializeField] public TileSpawner tileSpawner;


    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player") {
            player = other.GetComponent<Player>();
            
            this.GetComponent<Renderer>().enabled = false;
            //TODO: sound

            tileSpawner.nextEnvironment();
        }
    }
}
