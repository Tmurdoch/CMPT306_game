using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRunner : MonoBehaviour
{
    [SerializeField] public Player player;
    [SerializeField] public bool active;

    // Start is called before the first frame update
    void Start()
    {
        active = true;
    }


    void Update() {
        if(active) {
            transform.Translate(Vector3.forward * Time.deltaTime * player.moveSpeed, Space.World);//translate off of world coords rather than local gameobject
        }
    }

    
    void FixedUpdate()
    {
        
    }
}
