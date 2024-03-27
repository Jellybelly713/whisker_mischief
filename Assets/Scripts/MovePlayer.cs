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
    Animator animator;

    Vector3 movementDir;
    public float movementForce = 10;
    public float rotationSpeed = 1f;


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
        ///////////////// moving in 4 directions
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        movementDir = transform.right * x + transform.forward * z;

        //Debug.Log(transform.forward);
        // this sets a magnitude so knock off controllers wont affect it 
        rb.AddForce(movementDir.normalized * movementForce);

        if(rb.velocity.magnitude > 5)
        {
            rb.velocity = rb.velocity.normalized * 5;
        }

        animator.SetFloat("Speed", rb.velocity.magnitude);

        /////////////////////////////jumping
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(Vector3.up * forceAmount, ForceMode.Impulse);
        }

        ////////////////////////Rotation


        rb.rotation = Quaternion.Euler(rb.rotation.eulerAngles + new Vector3(-rotationSpeed * Input.GetAxis("Mouse Y"), rotationSpeed * Input.GetAxis("Mouse X"), 0f));

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            canJump = true;
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