using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{

    [SerializeField] public float moveSpeed = 3.0f; 
    private float forwardSpeed = 3.0f;
    private float backwardSpeed = 1.5f;
    [SerializeField] float leftRightSpeed = 4.0f;

    [SerializeField] private GameObject PlayerProjectile;
    [SerializeField] private float fireRates = 0.1f;
    [SerializeField] private float fireTimes;

    static public bool canMove = false;
    [SerializeField] private float maxSpeed = 15.0f;
    [SerializeField] private float maxFireTimes = 50.0f;

    [SerializeField] private LevelBoundary LevelBoundary;



    public Vector3 jump;
    public float jumpForce = 4.0f;

    public bool isGrounded;
    public Rigidbody rb;

    [SerializeField] public float health = 100.0f;

    void Start(){
             rb = GetComponent<Rigidbody>();
             jump = new Vector3(0.0f, 2.0f, 0.0f); //save jump vector so we don't create one on every frame

         }
     
    

    // Update is called once per frame
    void Update()
    {
        //moveSpeed += 0.1f;
        
        if (canMove) {
        //Move forward
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);//translate off of world coords rather than local gameobject
        //Side to side movement
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            if (this.gameObject.transform.position.x > LevelBoundary.leftBoundary) {
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
            }
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            if (this.gameObject.transform.position.x < LevelBoundary.rightBoundary) {
                transform.Translate(Vector3.right * Time.deltaTime * leftRightSpeed);
            }
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            if (this.gameObject.transform.position.z < LevelBoundary.frontBoundary) {
                transform.Translate(Vector3.forward * Time.deltaTime * leftRightSpeed);
            }
            
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            if (this.gameObject.transform.position.z > LevelBoundary.backBoundary) {
                transform.Translate(Vector3.back * Time.deltaTime * leftRightSpeed);
            }
        }
        //jump
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
     
                 rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                 isGrounded = false;
        }
        }

        Shoot();

    }

    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag == "FloorTile") {
            isGrounded = true;
        }
    }

    public void TakeDamage (float damage) {
        health -= damage; 
        if (health <= 0) {
            Debug.Log("should take damage");
            //GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
            //Destroy(effect, 1.0f); 
            Destroy(this.gameObject);     
            //reload scene
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);

        }
    }

    public void toggleMoving() {
        if (moveSpeed > 0) {
            moveSpeed = 0;
        }
        else {
            moveSpeed = 3.0f;

	}
    }
    private void Shoot() {
        if (Time.time > fireTimes) {
            var projectile = Instantiate(PlayerProjectile, transform.position, transform.rotation);
            Destroy(projectile, 20.0f);
            if(fireTimes <= maxFireTimes + fireRates) {
                fireTimes = Time.time + fireRates;
            } else {
                fireTimes = maxFireTimes;
            }
        }
    }

    //called from collision - PowerUp
    public void increaseSpeed() {
        if(moveSpeed + 3 <= maxSpeed) {
            moveSpeed += 3f;
            leftRightSpeed += 1.5f;
        } else {
            moveSpeed = maxSpeed;
        }
    }

    public void decreaseSpeed() {
        moveSpeed -= 3f;
    }
        

    public void Die() {
        health = 0;
    }
}
