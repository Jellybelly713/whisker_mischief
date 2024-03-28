using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AngryZone : MonoBehaviour
{
    public Transform[] BotPoints;
    NavMeshAgent navAgent;
    int currentBotPointIndex = 0;
    Animator animator;
    public int roboSpeed = 5;

    GameObject chaseTarget;

    enum GuardState { Patroling, Chasing, Fallen, Alert };
    GuardState currentState = GuardState.Patroling;

    // bool isNotIdle = true;

    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.SetDestination(BotPoints[currentBotPointIndex].position);

        animator = GetComponent<Animator>();

    }

    IEnumerator IdleDelayCoroutine()
    {
        //set speed to 0
        animator.SetFloat("SpeedBot", 0f);

        //wait 3 seconds
        yield return new WaitForSeconds(3);
        // set speed to 1
        animator.SetFloat("SpeedBot", 1.0f);
        // isNotIdle = false;

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
                Debug.Log("fallen");

                transform.Rotate(0, 0, 0);
                StartCoroutine(Wait5Coroutine());
                transform.Rotate(0, 0, 0);


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

    IEnumerator Wait5Coroutine()
    {

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);
        SwitchState(GuardState.Patroling);
        navAgent.SetDestination(BotPoints[currentBotPointIndex].position);
    }
}


