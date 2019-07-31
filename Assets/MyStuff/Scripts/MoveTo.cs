using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{

    public Transform goal;
    public Vector3 goalpos;
    public Vector3 thispos;
    public float distance;
    public int stopDistance;
    public int runDistance;

    private void Update()
    {
        thispos = transform.position;
        goalpos = goal.transform.position;
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        distance = Vector3.Distance(goalpos, thispos);
        if (distance >= stopDistance)
        {
            agent.destination = goal.position;
        } else if (distance < stopDistance && distance > runDistance)
        {
            agent.destination = thispos;
            this.transform.LookAt(goalpos);
        } else if (distance <= runDistance)
        {
            agent.destination = -goal.position;
        }
    }
}