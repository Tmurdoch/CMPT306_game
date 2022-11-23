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
    public static GameManager instance = null; 
    
    
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
    }

    public void addCoins(int coins) {
        coinCount += coins;
        if(coinCount % 10 == 0) {
                PauseGame();
                shop.SetActive(true);
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

        
}
