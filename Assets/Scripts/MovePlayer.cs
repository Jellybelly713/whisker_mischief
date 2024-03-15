using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    public float speed = 5;
    public float forceAmount = 20;
    bool canJump = false;

    [SerializeField] private float mouseSensitivity = 200f;
    public Vector2 turn;


    public Rigidbody rb;
    Animator animator;
    Vector3 movement;
    public Score changeScore;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        /////////////////// moving in 4 directions


        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        /*
        if (forceControlx > 0.2f)
        {
            forceControlx = 0.2f;
        }

        if (forceControlz > 0.2f)
        {
            forceControlz = 0.2f;
        }

        movement = new Vector3(forceControlx, 0, forceControlz);
        // this sets a magnitude so knock off controllers wont affect it 
        rb.AddForce(movement, ForceMode.Impulse);

        */

        /////////////////////////////jumping
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(new Vector3(0, forceAmount, 0), ForceMode.Impulse);
        }


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
        // Cat - physics based 
        rb.velocity = movement * speed;

    }

    /*
    on trigger enter collider other

     */
}


/*
 References
    https://gamedevbeginner.com/how-to-move-objects-in-unity/
 */