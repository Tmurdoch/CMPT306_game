using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    public AudioSource coinFX;

    void onTriggerEnter(Collider other)
    {
        coinFX.Play();
        CoinCounter.coinCount += 1;
        this.gameObject.SetActive(false);
    }
}
