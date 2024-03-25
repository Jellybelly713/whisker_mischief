using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody rb;
    public float forceAmount = 10;
    bool canJump = false;
    Animator animator;
    Vector3 movement;

    Vector3 movementDir;
    public float movementForce = 50;
    Vector3 counterMovement;
    public float counterMovementForce = 5;
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
        /////////////////// moving in 4 directions
        movementDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        counterMovement = new Vector3(-rb.velocity.x * counterMovementForce, 0, -rb.velocity.z * counterMovementForce);

        /////////////////////////////jumping
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(Vector3.up * forceAmount, ForceMode.Impulse);
        }

        ////////////////////////Rotation
       
        /*
         * if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, 2, 0);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -2, 0);
        }



        if (movement != Vector3.zero)
        {
            animator.SetFloat("Speed", 1.0f);
        }
        else
        {
            animator.SetFloat("Speed", 0.0f);
        }
        */
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
        rb.AddForce(movementDir.normalized * movementForce + counterMovement);
    }


    /*
    on trigger enter collider other

     */
}
 

/*
 References
    https://gamedevbeginner.com/how-to-move-objects-in-unity/
 */