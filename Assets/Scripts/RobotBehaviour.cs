using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotBehaviour : MonoBehaviour
{
    public Transform[] Waypoints;
    NavMeshAgent navAgent;
    int currentWaypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.SetDestination(Waypoints[currentWaypointIndex].position);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dest = new Vector2(navAgent.destination.x, navAgent.destination.z);
        Vector2 here = new Vector2(transform.position.x, transform.position.z);


        if ((dest - here).magnitude < 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % Waypoints.Length;
            navAgent.SetDestination(Waypoints[currentWaypointIndex].position);

        }
    }
}
