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

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        /////////////////// moving in 4 directions
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        movement = new Vector3(x, 0, z);
        // this sets a magnitude so knock off controllers wont affect it 
        movement = Vector3.ClampMagnitude(movement, 1);

        transform.Translate(movement * speed * Time.deltaTime);

        /////////////////////////////jumping
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(Vector3.up * forceAmount, ForceMode.Impulse);
        }

        ////////////////////////Rotation
        if (Input.GetKey(KeyCode.E))
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

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            canJump = false;
        }
    }
}


/*
 References
    https://gamedevbeginner.com/how-to-move-objects-in-unity/
 */