using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LookingScript : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform destination;
    public Transform newLap;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ObstacleControls.enemyComing == true && UIControls.go)
        {
            agent.destination = newLap.position;
        }
        else if (UIControls.go)
        {
            agent.destination = destination.position;
        }
    }
}
