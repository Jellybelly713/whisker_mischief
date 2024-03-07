using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveRobot : MonoBehaviour
{
    public Transform[] BotPoints;
    NavMeshAgent navAgent;
    int currentBotPointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.SetDestination(BotPoints[currentBotPointIndex].position);
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

        }
    }
}
