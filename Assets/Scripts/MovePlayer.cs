using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed = 5;
    public Rigidbody rb;
    public float forceAmount = 10;
    bool canJump = false;
    Animator animator;

    Vector3 movementDir;
    public float movementForce = 10;

    public Score changeScore;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        ///////////////// moving in 4 directions
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        movementDir = new Vector3(x, 0, z);
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