using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveRobot : MonoBehaviour
{

    public Transform[] RobotPathPoints;
    NavMeshAgent navAgent;
    int currentRobotPathIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.SetDestination(RobotPathPoints[0].position);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dest = new Vector2(navAgent.destination.x, navAgent.destination.z);
        Vector2 here = new Vector2(transform.position.x, transform.position.z);


        if ((dest - here).magnitude < 0.01f)
        {
            currentRobotPathIndex = (currentRobotPathIndex +1) % RobotPathPoints.Length;
            navAgent.SetDestination(RobotPathPoints[currentRobotPathIndex].position);
        }
    }
}
