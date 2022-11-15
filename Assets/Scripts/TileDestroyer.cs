using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDestroyer : MonoBehaviour
{
    void Update() {
        Transform target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
         Vector3 toTarget = (target.position - transform.position).normalized;
            if (Vector3.Dot(toTarget, transform.forward) < 0) {
                Destroy(this);
                Debug.Log("destroyed" + this);
            }
    }
}
