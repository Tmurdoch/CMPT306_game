using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class GameManager : MonoBehaviour
{
    //CoinsSo + scoreSO are a reference to the asset in the editor, so it 
    //will persist across scene changes
    //see Assets/Scripts/SoData
    [SerializeField] public IntSO coinsSO;

    [SerializeField] public Text coinText;

    [SerializeField] public IntSO scoreSO;

    [SerializeField] public Text scoreText;

    [SerializeField] public Player player;

    [SerializeField] public GameObject shop;

    [SerializeField] public PlayerMelee playerMelee;

    [SerializeField] public GameObject shopbutton;


    //for debugging
    [SerializeField] public int coinsToSpawnShop = 10;

    public static GameManager instance = null;

    private bool shownShop = false;

    private bool showingShop = false; //there is no method in GO for this

    private int distPerPoint = 10;

    void Awake() {
        if (instance == null) {
            instance = this;
        } 

        else if (instance != this) {
            Destroy(gameObject); 
        }
    }

    void Update()
    {
        coinText.text = "Coins: " + coinsSO.Value;
        //add one point for each meter
        if (transform.position.z / 10 > distPerPoint) {
            addScore(1);
            distPerPoint += 10;
        }
        
        scoreText.text = "Score: " + scoreSO.Value;
    }

    public void addScore(int score) {
        scoreSO.Value += score;
    }

    public void addCoins(int coins) {
        coinsSO.Value += coins;

        //show shop for first time on 10th coin
        if (shownShop == false)
            {
            if (coinsSO.Value >= coinsToSpawnShop) {
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
        if(coinsSO.Value >= 10 && player.health < 100) {
            removeCoins(10);
            player.healPlayer();
        }
    }

    public void purchaseShootFaster() 
    {
        if(coinsSO.Value >= 20) {
            removeCoins(20);
            playerMelee.increaseSpeed();
        }
    }

    public void removeCoins(int coins) {
        coinsSO.Value -= coins;
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
