using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{

    [SerializeField] float moveSpeed = 3.0f; 
    [SerializeField] float leftRightSpeed = 4.0f;

    public Vector3 jump;
    public float jumpForce = 2.0f;

    public bool isGrounded;
    public Rigidbody rb;

    void Start(){
             rb = GetComponent<Rigidbody>();
             jump = new Vector3(0.0f, 2.0f, 0.0f); //save jump vector so we don't create one on every frame
         }
     
    

    // Update is called once per frame
    void Update()
    {
        //Move forward
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);//translate off of world coords rather than local gameobject
        
        //Side to side movement
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            if (this.gameObject.transform.position.x > LevelBoundary.leftSide) {
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
            }
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            if (this.gameObject.transform.position.x < LevelBoundary.rightSide) {
                transform.Translate(Vector3.right * Time.deltaTime * leftRightSpeed);
            }
        }
        //jump
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
     
                 rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                 isGrounded = false;
        }

    }

    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.name == "Floor") {
            isGrounded = true;
        }
    }
}
