using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    void Start()
    {
        
        Cursor.visible = true;
    }



    public GameObject player;
    public float smoothTime = 0.5f;
    public float rotationSpeed = 5f; // Adjust the rotation speed as needed
    Vector3 currentVelocity;
    Quaternion tiltOffset = Quaternion.Euler(-15, 0f, 0f);
    Quaternion Turnto; //Quaternion is the vector but for roation & smoothDamp doesn't work on it so I used Slerp instead
    void Update()
    {

        // set the camera to always be behind the player
        Vector3 desiredPosition = player.transform.position + player.transform.forward * -10f + Vector3.up * 10f;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref currentVelocity, smoothTime);

        //if the player rotates so does the camera ----- player look left camera look left
        Quaternion desiredRotation = Quaternion.LookRotation(player.transform.position - transform.position) * tiltOffset;
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, smoothTime);

        //makes sure the camera rotate around the player
        ///transform.RotateAround(player.transform.position, Vector3.up, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);


    }
}


/*
 References
https://docs.unity3d.com/ScriptReference/Transform.html
*/