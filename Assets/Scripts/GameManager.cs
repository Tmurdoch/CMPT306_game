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
    //for debugging
    [SerializeField] public int coinsToSpawnShop = 10;

    public static GameManager instance = null;

    private bool shownShop = false;

    private bool showingShop = false; //there is no method in GO for this


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

    public void addCoins(int coins) {
        coinCount += coins;

        //show shop for first time on 10th coin
        if (shownShop == false)
            {
            if (coinCount == coinsToSpawnShop) {
                shownShop = true;
                toggleshop();
            }
        }
    }

    public void toggleshop()
    {
        if (!showingShop) {
            PauseGame();
            shop.SetActive(true);
            shopbutton.SetActive(false);
            showingShop = true;
        }
        else {
            ResumeGame();
            shop.SetActive(false);
            shopbutton.SetActive(true);
            showingShop = false;
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
