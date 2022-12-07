using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioClip damageSound;
    public AudioClip deathSound;

    [SerializeField] private GameObject Coin;

    public float moveSpeed = 1.0f;

    public GameObject bulletPrefab;
    public float shootSpeed = 0.5f;

    private float fireRate = 0.5f; //fired a second
    private float lastAttackTime = 0f;
    private Transform player = null;
    private Player actual_player = null;
    private bool playerInRange = false;

    private float enemyHealth = 50.0f;

    private float collisionDamage = 10.0f;

    private float chanceSpawnCoin = 0.55f;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            other.GetComponent<Player>().TakeDamage(collisionDamage); 
        }
    }

    void OnTriggerExit(Collider other) {
    }

    void Start() {
       actual_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
       player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        if (player) {
            float dist = Vector3.Distance(player.position, transform.position);
            if(dist <= 7) {
                transform.LookAt(player);
                if (Time.time - lastAttackTime >= 1f / fireRate)  {
                    shoot();
                    lastAttackTime = Time.time;
                    }
                Vector3 toPlayer = (player.position - transform.position).normalized;
                if (Vector3.Dot(toPlayer, transform.forward) > 0) {
                    transform.Translate(Vector3.forward * Time.deltaTime * actual_player.moveSpeed, Space.World);//translate off of world coords rather than local gameobject
                }
            } else {
                 // Move our position a step closer to the target.
                    var step =  actual_player.moveSpeed * Time.deltaTime; // calculate distance to move
                    transform.position = Vector3.MoveTowards(transform.position, player.position, step);

                    // Check if the position of the cube and sphere are approximately equal.
                    if (Vector3.Distance(transform.position, player.position) < 0.001f)
                    {
                        // Swap the position of the cylinder.
                        player.position *= -1.0f;
                    }
            }
        }
    }

    public void TakeDamage (float damage) {
        enemyHealth -= damage; 
        AudioSource.PlayClipAtPoint(damageSound, transform.position);
        if (enemyHealth <= 0) {
            
            //spawn coins only only sometimes, probability based on 'chanceSpawnCoin' instance variable
            float chance = Random.value;
            
            if (chance < chanceSpawnCoin) {
                Instantiate(Coin, transform.position, new Quaternion(0, 0, 0, -90));   
            }

            Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(deathSound, transform.position);

            //tell game manager to increase score
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().addScore(5);
            }
    }

    void shoot() {
        var projectile = Instantiate(bulletPrefab, transform.position, transform.rotation);
        // projectile.velocity = transform.forward * shootSpeed;
    }
}
