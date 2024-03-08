using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveRobot : MonoBehaviour
{
    public Transform[] BotPoints;
    NavMeshAgent navAgent;
    int currentBotPointIndex = 0;
    Animator animator;

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
        Vector2 dest = new Vector2(navAgent.destination.x, navAgent.destination.z);
        Vector2 here = new Vector2(transform.position.x, transform.position.z);

        if ((dest - here).magnitude < 0.01f)
        {
            currentBotPointIndex = (currentBotPointIndex + 1) % BotPoints.Length;
            navAgent.SetDestination(BotPoints[currentBotPointIndex].position);
           /*
            while (isNotIdle == true)
            {
               Debug.Log("in while loop");
                  StartCoroutine(IdleDelayCoroutine());
           }
            */
        }
    }
}
