using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryCoin : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            // GameManager.instance.AddCoins(1);
            Destroy(transform.parent.gameObject);
        }
    }
}
