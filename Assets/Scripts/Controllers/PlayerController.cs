using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody theRB;
    public float jumpForce, respawnLength, maxSpeed = 3.0f, checkerRange = 0.0f;
    private Vector3 moveDirection, respawnPostion;
    public GameObject groundChecker;
    public LayerMask whatIsGround;
    bool isOnGround = false, isRespawning;
    Animator myAnim;
    

    void Start()
    {
        theRB = GetComponent<Rigidbody>();
        myAnim = GetComponentInChildren<Animator>();

        respawnPostion = this.gameObject.transform.position;
    
    }


    void Update()
    {
        // Player Movement Code Rigidbody
        
        moveDirection = new Vector3(Input.GetAxis("Horizontal") * maxSpeed, moveDirection.y, Input.GetAxis("Vertical") * maxSpeed);

        moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));

        moveDirection = moveDirection.normalized * maxSpeed;
        myAnim.SetFloat("speed", moveDirection.magnitude);  

        isOnGround = Physics.CheckSphere(groundChecker.transform.position, checkerRange, whatIsGround);
        myAnim.SetBool("isOnGround", isOnGround);

        if(Input.GetKeyDown(KeyCode.Space) && isOnGround == true){
            theRB.linearVelocity = new Vector3(0.0f, 0.0f, 0.0f);
            theRB.AddForce(new Vector3(0.0f, jumpForce, 0.0f));
            myAnim.SetTrigger("jumped");
        }

        theRB.linearVelocity = new Vector3(moveDirection.x, theRB.linearVelocity.y, moveDirection.z);


    }

    public void Pads(float padForce)
    {
        theRB.linearVelocity = new Vector3(0.0f, 0.0f, 0.0f);
        theRB.AddForce(new Vector3(0.0f, padForce, 0.0f));
    }


}
