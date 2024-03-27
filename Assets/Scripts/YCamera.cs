using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YCamera : MonoBehaviour
{
    public float Speed = 5;
    public Rigidbody rb;
    public float forceAmount = 25;
    bool canJump = false;
    Animator animator;

    Vector3 movementDir;
    public float movementForce = 10;
    public float rotationSpeed = 1f;

    private Vector3 turn;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        ///////////////// moving in 4 directions
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        movementDir = transform.right * x + transform.forward * z;
      
        /////////////////////////////jumping
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(Vector3.up * forceAmount, ForceMode.Impulse);
        }


        ////////////////////////Rotation
        rb.rotation = Quaternion.Euler(rb.rotation.eulerAngles + new Vector3(-rotationSpeed * Input.GetAxis("Mouse Y"), 0f, 0f));

    }
}

   


  


/*
 References
    https://gamedevbeginner.com/how-to-move-objects-in-unity/
 */