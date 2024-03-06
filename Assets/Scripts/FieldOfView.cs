using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    [HideInInspector] 
    public List<Transform> visiableTargets = new List<Transform>();

    void Start()
    {
        StartCoroutine("FindTargetWithDelay", .2f);
    }

        IEnumerable FindTargetWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisableTargets();
        }
    }

    void FindVisableTargets()
    {
        visiableTargets.Clear();
        Collider[] targetsInViewRadius = Physics.OverlapSphere (transform.position, viewRadius, targetMask);
        
        for (int i = 0;i < targetsInViewRadius.Length;i++) 
        { 
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = ( target.position - transform.position).normalized;
            if(Vector3.Angle(transform.forward, dirToTarget) < viewAngle /2) 
            { 
                float dsToTarget = Vector3.Distance(transform.position, target.position);
                if(!Physics.Raycast (transform.position, dirToTarget, dsToTarget, obstacleMask))
                {
                    // Points decrease code here
                    visiableTargets.Add(target);
                }
            }
        }
    }


    public Vector3 DiFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal) 
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));

    }

}
// Reference -> https://www.youtube.com/watch?v=rQG9aUWarwE