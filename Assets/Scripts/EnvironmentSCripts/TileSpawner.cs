using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TileSpawner : MonoBehaviour
{
    public GameObject[] tiles; 
    public float zPos = 54.3f; //tile length in z direction
    public bool creatingTile = false;
    public int tile_num;
    public float waitTime; 

    public GameObject powerup;
    public GameObject coinSpawner;
    public GameObject Portal;

    [SerializeField] public int minPortalSpeed = 20;

    [SerializeField] public Player player;

    private bool shouldSpawnPortal = false;

    Scene currentScene;

    void Start() {
        player.speedIncreaseEvent.AddListener(portalCheck);
    }

    // Update is called once per frame
    void Update()
    {
        waitTime = 10 / player.moveSpeed;
        if (creatingTile == false) {
            creatingTile = true;
            StartCoroutine(GenerateTile());
        }
    }

    IEnumerator GenerateTile() {
        //update current scene
        currentScene = SceneManager.GetActiveScene();

        //switch the tiles based on which scene we are on
        string sceneName = currentScene.name;
        if (sceneName == "main_scene") { 
            tile_num = Random.Range(0 , 3);
        }
        else if (sceneName == "desert_level") {
            tile_num = Random.Range(3, 6);
        }
        
        Instantiate(tiles[tile_num], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 54.3f;
        Instantiate(powerup, new Vector3(Random.Range(-8, 8), 1, zPos), Quaternion.identity);
        if (shouldSpawnPortal) {
            Instantiate(Portal, new Vector3(Random.Range(-8, 8), 1, zPos), Quaternion.identity);
            shouldSpawnPortal = false;
            player.resetMoveSpeed();
        }
        yield return new WaitForSeconds(waitTime); 
        creatingTile = false;
    }

    private void portalCheck() {
        if (player.moveSpeed >= minPortalSpeed) {
            Debug.Log("WE SHOULD SPAWN A PORTAL");
            shouldSpawnPortal = true;
        }
    }

    public void nextEnvironment() {
        int buildIndex = currentScene.buildIndex;

        switch (buildIndex) {
            case 1:
                SceneManager.LoadScene(2);
                break;
            case 2:
                SceneManager.LoadScene(1);
                break;
        }
    }

}