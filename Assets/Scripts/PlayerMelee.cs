using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{

    private Transform player;
    [SerializeField] private float damage = 50.0f;
    [SerializeField] private float rotateSpeed = 50.0f;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(player.transform.position, Vector3.up, rotateSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other) {
        if (other.transform.tag == "Enemy") {
            other.GetComponent<Enemy>().TakeDamage(damage); 
        }
    }

    public void increaseSpeed() {
        this.rotateSpeed = this.rotateSpeed * 2.0f;
    }
}
