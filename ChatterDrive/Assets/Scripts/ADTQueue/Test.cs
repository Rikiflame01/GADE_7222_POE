using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Test : MonoBehaviour
{
    [SerializeField] private NavMeshAgent racerAgent;
    [SerializeField] private ADTGraph graph;

    public int waypointIndex = 0;

    void Start()
    {
        racerAgent = GetComponent<NavMeshAgent>();
        graph = ADTGraph.Instance; // Assuming you have a singleton instance for your graph.
        SetNextRacerDestination();
    }

    void Update()
    {
        // Check if the racer has reached the current destination
        if (!racerAgent.pathPending &&
            racerAgent.remainingDistance <= racerAgent.stoppingDistance &&
            (!racerAgent.hasPath || racerAgent.velocity.sqrMagnitude == 0f))
        {
            waypointIndex++;
            SetNextRacerDestination();
        }
    }

    private void SetNextRacerDestination()
    {
        GraphNode nextNode = graph.GetNextNode(this);
        racerAgent.SetDestination(nextNode.nodeTransform.position);
    }
}
