using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollider : MonoBehaviour
{    
    private float moveSpeed = 10.0f;
    private bool isTouched;
    [SerializeField] public AudioClip coinSound;
    

    // Update is called once per frame
    void Update()
    {
        if (isTouched)
        {
            Movement();
        }
    }
    private void Movement()
    {
            transform.LookAt(GameObject.FindWithTag("Player").transform.position);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            GameManager.instance.addCoins(1);
            isTouched = true;
            AudioSource.PlayClipAtPoint(coinSound, transform.position);
            Destroy(this.gameObject);
        }
    }
}