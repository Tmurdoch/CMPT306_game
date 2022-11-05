using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour 
{

    public GameObject charModel;
    void OnTriggerEnter(Collider other) {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        other.GetComponent<Player>().toggleMoving();
        charModel.GetComponent<Animator>().Play("Stumble Backwards");
    }
}
