using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    public NavMeshAgent agent;

    public GameObject bobber;

    private float dist;

    public float speed, walkRadius, detectionRadius;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        bobber = GameObject.FindGameObjectWithTag("bobber");
        if(agent != null)
        {
            agent.speed = speed;
            agent.SetDestination(RandomMeshLocation());
        }
    }

    // Update is called once per frame
    void Update()
    {
        bobber = GameObject.FindGameObjectWithTag("bobber");
        dist = Vector3.Distance(bobber.transform.position, agent.transform.position);

        if (agent != null && dist <= detectionRadius)
        {
            agent.SetDestination(bobber.transform.position);
        }

        if (agent != null && dist > detectionRadius)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                agent.SetDestination(RandomMeshLocation());
            }
        }
    }

    public Vector3 RandomMeshLocation()
    {
        Vector3 finalPosition = Vector3.zero;
        Vector3 randomPosition = Random.insideUnitSphere * walkRadius;
        randomPosition += transform.position;
        if (NavMesh.SamplePosition(randomPosition, out NavMeshHit hit, walkRadius, 1))
            {
            finalPosition = hit.position;
            }
        return finalPosition;
    }
}
