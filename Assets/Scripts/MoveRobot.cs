using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class MoveRobot : MonoBehaviour
{
    public CapsuleCollider hit;

    public Transform[] BotPoints;
    NavMeshAgent navAgent;
    int currentBotPointIndex = 0;
    public int roboSpeed = 5;

    GameObject chaseTarget;

    float fallAngle = 0;
    enum GuardState { Patroling, Chasing, Fallen, Alert};
    GuardState currentState = GuardState.Patroling;

    // bool isNotIdle = true;

    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.SetDestination(BotPoints[currentBotPointIndex].position);
        

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
                Vector2 dest = new Vector2(navAgent.destination.x, navAgent.destination.z);
                Vector2 here = new Vector2(transform.position.x, transform.position.z);

                if ((dest - here).magnitude < 0.01f)
                {
                    currentBotPointIndex = (currentBotPointIndex + 1) % BotPoints.Length;
                    navAgent.SetDestination(BotPoints[currentBotPointIndex].position);

                }
                break;
            case GuardState.Chasing:
                navAgent.SetDestination(chaseTarget.transform.position);

                break;

            case GuardState.Fallen:

                Debug.Log("fallen in update");
                SwitchState(GuardState.Fallen);


                break;

            case GuardState.Alert:
                break;

            default:
                break;
        }


    }

    void SwitchState(GuardState newState)
    {
        switch(currentState)
        {
            case GuardState.Chasing:
                if(newState == GuardState.Patroling) 
                {
                    navAgent.SetDestination(BotPoints[currentBotPointIndex].position);
                }

                if (newState == GuardState.Fallen)
                {
                    Debug.Log("fallen in switchState");

                    hit.enabled = false;

                    StartCoroutine(fallingCoroutine());
                    hit.enabled = true;


                }

                break;

            //case GuardState.Fallen:
               // Debug.Log("fallen in switchState");

           
                  //  StartCoroutine(fallingCoroutine());
                
               // break;
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

        fallAngle = 0;
        while (fallAngle<90)        
        {
            fallAngle += 5f;
            transform.Rotate(0.0f, 0.0f, fallAngle); // Rotate around Z-axis
            yield return new WaitForSeconds(1f);
            Debug.Log("increase tilt by 5");


            if (fallAngle >= 90)
            {
                Debug.Log("STOP");
            }
        }


        /*
                yield return new WaitForSeconds(5f);

                for (int i = 90; i > 0; i--)
                {
                    transform.Rotate(0, 0, fallAngle);
                    fallAngle = fallAngle - 1f;
                    yield return new WaitForSeconds(0.4f);
                    Debug.Log("back up");

                }
        */
        SwitchState(GuardState.Patroling);
        navAgent.SetDestination(BotPoints[currentBotPointIndex].position);
    }
}
