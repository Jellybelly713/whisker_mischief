using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MoveRobot : MonoBehaviour
{
    public CapsuleCollider hit;

    public Transform[] BotPoints;
    public NavMeshAgent navAgent;
    int currentBotPointIndex = 0;
    public int roboSpeed = 5;

    public float timeVar;

    GameObject chaseTarget;

    float fallAngle = 0;
    enum GuardState { Patroling, Chasing, Fallen, Falling, Alert};
    GuardState currentState = GuardState.Patroling;

    public GameObject spottedImg;
    

    // bool isNotIdle = true;

    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.SetDestination(BotPoints[currentBotPointIndex].position);
 

        hit.enabled = true;
        navAgent.enabled = true;


        spottedImg.SetActive(false);
    }

    IEnumerator IdleDelayCoroutine()
    {
        //wait 3 seconds
        yield return new WaitForSeconds(3);
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case GuardState.Patroling:
                fallAngle = 0;

                Vector2 dest = new Vector2(navAgent.destination.x, navAgent.destination.z);
                Vector2 here = new Vector2(transform.position.x, transform.position.z);

                if ((dest - here).magnitude < 0.01f)
                {
                    currentBotPointIndex = (currentBotPointIndex + 1) % BotPoints.Length;
                    navAgent.SetDestination(BotPoints[currentBotPointIndex].position);

                }
                spottedImg.SetActive(false);

                break;
            case GuardState.Chasing:
                navAgent.SetDestination(chaseTarget.transform.position);
                spottedImg.SetActive(true);

                break;

            case GuardState.Fallen:

                Debug.Log("fallen in update");
                SwitchState(GuardState.Falling);

                break;


            case GuardState.Falling:

                break;
            case GuardState.Alert:

                break;

            default:
                break;
        }


    }

    void SwitchState(GuardState newState)
    {
        switch (currentState)
        {
            case GuardState.Chasing:
                if (newState == GuardState.Patroling)
                {
                    navAgent.SetDestination(BotPoints[currentBotPointIndex].position);
                }
                break;


            case GuardState.Fallen:
                if (newState == GuardState.Falling) { 

                    Debug.Log("falling in switchState");


                    StartCoroutine(fallingCoroutine());

                }

                break;
      
        }

        currentState = newState;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            switch (currentState) 
            {
                case GuardState.Patroling:
                    chaseTarget = other.gameObject;
                    //spottedImg.SetActive(true);
                    SwitchState(GuardState.Chasing); 
                    break;
                default:
                    break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            switch (currentState)
            {
                case GuardState.Chasing:
                    chaseTarget = null;
                    //spottedImg.SetActive(false);
                    SwitchState(GuardState.Patroling);
                    break;
                default:
                    break;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //spottedImg.SetActive(false);

            switch (currentState)
            {
                case GuardState.Chasing:
                    chaseTarget = null;
                    SwitchState(GuardState.Fallen);
              
                    break;

                case GuardState.Patroling:
                    chaseTarget = null;
                    SwitchState(GuardState.Fallen);

                    break;

                case GuardState.Alert:
                    chaseTarget = null;
                    SwitchState(GuardState.Fallen);
                    break;

                default:
                    break;
            }
        }
    }

    IEnumerator fallingCoroutine()
    {

        Debug.Log("entered coroutine");
        hit.enabled = false;
        navAgent.enabled = false;

        while (fallAngle < 90)
        {
            //fallAngle = Mathf.Lerp(0, 90, timeVar);

            fallAngle = 5f;
            transform.Rotate(0.0f, 0.0f, fallAngle); // Rotate around Z-axis
            Debug.Log("increase tilt by 5");
            Debug.Log(fallAngle) ;

            timeVar += Time.deltaTime * 60;

            if (fallAngle >= 90)
            {
                Debug.Log("STOP");
            }
            yield return new WaitForSeconds(0.3f);
            Debug.Log(fallAngle);

        }
        SwitchState(GuardState.Patroling);
        navAgent.SetDestination(BotPoints[currentBotPointIndex].position);
        timeVar = 0;
        hit.enabled = true;
        navAgent.enabled = true;

    }
}
