using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollider : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private bool isTouched;
    // Start is called before the first frame update
    void Start()
    {

    }

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
             CoinCounter.coinCount += 1;
            isTouched = true;
        }
    }
}