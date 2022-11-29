using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        tile_num = Random.Range(0 , 3);
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
            Debug.Log("we should spawn a portal");
            shouldSpawnPortal = true;
        }
    }

    public void nextEnvironment() {
        //TODO
        Debug.Log("NOT IMPLEMENTED, WE SHOULD SPAWN NEW TILES NOW");
    }

}