using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed = 5;
    public Rigidbody rb;
    public float forceAmount = 25;

    bool canJump = false;
    bool canMove = false;

    Animator animator;

    Vector3 movementDir;
    public float movementForce = 10;
    public float rotationSpeed = 0.5f;


    public Score changeScore;

    private Vector3 turn;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (canJump || canMove) { 

            ///////////////// moving in 4 directions
            float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        movementDir = transform.right * x + transform.forward * z;

        //Debug.Log(transform.forward);
        // this sets a magnitude so knock off controllers wont affect it 
        /*
          */


            // camera is giving it a y velocity making it fly
            // need to fix this
        rb.AddForce(movementDir.normalized * movementForce);

        if(rb.velocity.magnitude > 5)
        {
            rb.velocity = rb.velocity.normalized * 5;
        }

        animator.SetFloat("Speed", rb.velocity.magnitude);

        }
        /////////////////////////////jumping
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            Debug.Log("jumpled");
            rb.AddForce(new Vector3(0f, forceAmount, 0f), ForceMode.Impulse);
        } else if (Input.GetKeyDown(KeyCode.Space) && canJump) {
            Debug.Log("can't jumpled");
        }


        ////////////////////////Rotation


        rb.rotation = Quaternion.Euler(rb.rotation.eulerAngles + new Vector3(0f, rotationSpeed * Input.GetAxis("Mouse X"), 0f));
        //rb.rotation = Quaternion.Euler(rb.rotation.eulerAngles + new Vector3(-rotationSpeed * Input.GetAxis("Mouse Y"), rotationSpeed * Input.GetAxis("Mouse X"), 0f));

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            canJump = true;
            canMove = true;
        }

        if (other.gameObject.CompareTag("angryZone"))
        {
            changeScore.CollisionNegPnt();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            canJump = false;
        }
    }

    private void FixedUpdate()
    {
    }



    /*
    on trigger enter collider other

     */
}


/*
 References
    https://gamedevbeginner.com/how-to-move-objects-in-unity/
 */