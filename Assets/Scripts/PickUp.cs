using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PickUp : MonoBehaviour
{
    [Header("Pickup Settings")]
    [SerializeField] Transform ObjectHolder;
    private GameObject heldObj;
    private Rigidbody heldObjRB;
    [SerializeField] private LayerMask pickUpLayerMask;

    [Header("Physics Parameters")]
    [SerializeField] private float pickupRange = 20.0f;
    [SerializeField] private float pickupForce = 150.0f;

    public GameObject pickupImg;
    public Collider knifeCollider;


    private void Start()
    {
        knifeCollider = GetComponent<Collider>();
        pickupImg.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObj == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange, pickUpLayerMask))
                {
                    PickupObject(hit.transform.gameObject);
                    pickupImg.SetActive(true);
                }
            }
            else
            {
                DropObject();
                pickupImg.SetActive(false);
            }
        }
        if (heldObj != null)
        {
            MoveObject();
        }
    }

    void MoveObject()
    {
        if (Vector3.Distance(heldObj.transform.position, ObjectHolder.position) > 0.1f)
        {
            Vector3 moveDirection = (ObjectHolder.position - heldObj.transform.position);
            heldObjRB.AddForce(moveDirection * pickupForce);
        }
    }

    void PickupObject(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            heldObjRB = pickObj.GetComponent<Rigidbody>();
            heldObjRB.useGravity = false;
            heldObjRB.drag = 10;
            heldObjRB.constraints = RigidbodyConstraints.FreezeRotation;

            heldObjRB.transform.parent = ObjectHolder;
            heldObj = pickObj;
        }
        Debug.Log("pick up");
        if(pickObj.tag == "knife"){
            Debug.Log("off");
            knifeCollider.enabled = false;
        }

    }

    void DropObject()
    {

        heldObjRB.useGravity = true;
        heldObjRB.drag = 1;
        heldObjRB.constraints = RigidbodyConstraints.None;

        heldObjRB.transform.parent = null;
        heldObj = null;
        if (heldObjRB.tag == "knife")
        {
            Debug.Log("on");
            knifeCollider.enabled = false;
        }
    }
}