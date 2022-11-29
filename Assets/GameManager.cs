using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static int coinCount;
    [SerializeField] public Text coinText;
    [SerializeField] public Player player;
    [SerializeField] public GameObject shop;
    [SerializeField] public GameObject shopbutton;
    public static GameManager instance = null;
    private bool firsttime = true;


    void Update()
    {
        coinText.text = "Coins: " + coinCount;
    }

    void Awake() {
        if (instance == null) {
            instance = this;
        } 

        else if (instance != this) {
            Destroy(gameObject); 
        }
    }


    public void purchaseHealth() {
        Debug.Log(player.health + "player health");
        if(coinCount >= 10 && player.health < 100) {
            removeCoins(10);
            player.healPlayer();
        }
    }

    public void purchaseShootFaster() 
    {
        if(coinCount >= 20) {
            removeCoins(20);
            player.increaseShotSpeed();
        }
    }

    public void exitShop() {
        ResumeGame();
        shop.SetActive(false);
        shopbutton.SetActive(true);
    }

    public void addCoins(int coins) {
        coinCount += coins;
        if (firsttime == true)
            {
            if (coinCount == 10) {
                PauseGame();
                shop.SetActive(true);
                firsttime = false;
            }
        }
    }

    public void removeCoins(int coins) {
        coinCount -= coins;
    }

    void PauseGame ()
        {
            Time.timeScale = 0;
        }
    void ResumeGame ()
        {
            Time.timeScale = 1;
        }
    public void toggleshop()
    {
        PauseGame();
        shop.SetActive(true);
        shopbutton.SetActive(false);
    }

}
