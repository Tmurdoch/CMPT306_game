using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] public float initialMoveSpeed = 7.5f;
    [SerializeField] public float moveSpeed = 7.5f; 
    private float forwardSpeed = 7.5f;
    private float backwardSpeed = 1.5f;
    [SerializeField] float leftRightSpeed = 4.0f;

    [SerializeField] private GameObject PlayerProjectile;
    [SerializeField] private float fireRates = 0.1f;
    [SerializeField] private float fireTimes;

    static public bool canMove = false;
    private float maxSpeed = 60.0f;
    [SerializeField] private float maxFireTimes = 50.0f;

    [SerializeField] private LevelBoundary LevelBoundary;

    //for game manager
    public UnityEvent speedIncreaseEvent = new UnityEvent();

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
            if (this.gameObject.transform.position.z < LevelBoundary.getfrontBoundary()) {
                transform.Translate(Vector3.forward * Time.deltaTime * leftRightSpeed);
            }
            
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            if (this.gameObject.transform.position.z > LevelBoundary.getbackBoundary()) {
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
        float temp = moveSpeed;
        if (moveSpeed > 0) {
            moveSpeed = 0;
        }
        else {
            moveSpeed = temp;
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
        if(moveSpeed + 6 <= maxSpeed) {
            moveSpeed += 6f;
            leftRightSpeed += 1.5f;
        } else {
            moveSpeed = maxSpeed;
        }
        speedIncreaseEvent.Invoke();
    }

    public void decreaseSpeed() {
        moveSpeed -= 3f;
    }

    // public void resetMoveSpeed() {
    //     moveSpeed = initialMoveSpeed;
    // }        

    public void Die() {
        health = 0;
    }

    public void healPlayer() {
        if(health < 100) {
            if(health + 10 <= 100) {
                health += 10;
            } else {
                health = 100;
            }
        }
    }

    public void increaseShotSpeed() 
    {
        fireRates = fireRates / 1.2f;
    }
}
