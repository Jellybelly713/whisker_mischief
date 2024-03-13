using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    Animator animator;
    public Score changeScore;

    Vector3 movement;
    public float speed = 5;

    public float forceAmount = 10f;
    bool canJump = false;
    public float fallMultiplier = 2f;

    public Vector3 mousePosition;
    float angle;


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
            rb.AddForce( Vector3.up * forceAmount, ForceMode.Impulse);
            Debug.Log("jump");

        }
        if ( rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * fallMultiplier * Time.deltaTime;
        }

        ////////////////////////Rotation
        ///
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * speed);











        if (movement != Vector3.zero)
        {
            animator.SetFloat("Speed", 1.0f);
        }
        else
        {
            animator.SetFloat("Speed", 0.0f);
        }

    }

    IEnumerator Rotate()
    {

        float moveSpeed = 10f;
        while (transform.rotation.z < angle)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angle), moveSpeed * Time.deltaTime);  //If I divide this Time.deltaTime by the integer it slows down the rotation speed like I want it to.
            yield return null;
        }

        transform.rotation = Quaternion.Euler(0, 0, angle);  //This sets it to the desired angle instantly, but without this when the mouse position changes the object freezes in place.
        yield return new WaitForSeconds(0.001f);
        StartCoroutine(Rotate());

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



    /*
    on trigger enter collider other

     */
}


/*
 References
    https://gamedevbeginner.com/how-to-move-objects-in-unity/
 */
