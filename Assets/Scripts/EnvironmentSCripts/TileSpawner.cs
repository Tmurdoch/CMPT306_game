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

    [SerializeField] public Player player;



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
        yield return new WaitForSeconds(waitTime); //TODO: change this, we will have increasing speed
        creatingTile = false;
    }
}