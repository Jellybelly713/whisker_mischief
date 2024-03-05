using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed = 5;
    public Rigidbody rb;
    public float forceAmount = 10;

    void Update()
    {
        /////////////////// moving in 4 directions
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(x, 0, z);
        // this sets a magnitude so knock off controllers wont affect it 
        movement = Vector3.ClampMagnitude(movement, 1);

        transform.Translate(movement * speed * Time.deltaTime);

        /////////////////////////////jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * forceAmount, ForceMode.Impulse);
        }

        ////////////////////////Rotation
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, 1, 0);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -1, 0);
        }
    }

}


/*
 References
    https://gamedevbeginner.com/how-to-move-objects-in-unity/
 */