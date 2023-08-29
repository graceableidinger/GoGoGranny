using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyDestination : MonoBehaviour
{
    public static bool interim;
    public Transform destination;
    public Transform newLap;
    public Transform inter;
    public static bool close;

    public bool enemyComing = false;


    NavMeshAgent agent;
    // Start is called before the first frame update
    private static EnemyDestination instance;
    public static EnemyDestination Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<EnemyDestination>();
                if (instance == null)
                {
                    GameObject test = new GameObject();
                    test.hideFlags = HideFlags.HideAndDontSave;
                    instance = test.AddComponent<EnemyDestination>();
                }
            }
            return instance;
        }
    }
    void Start()
    {
        interim = false;
        agent = GetComponent<NavMeshAgent>();       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (interim)
        //{
        //    agent.destination = inter.position;
        //}
        //else
        //{
            if (enemyComing == true && UIControls.go)
            {
                Debug.Log("true");
                agent.destination = newLap.position;
            }
            else if(UIControls.go)
            {
                agent.destination = destination.position;
            }
        //}
        //NavMeshAgent.// = destination.position; //(destination.position);
        //NavMeshAgent.SetDestination(7,18,16);
    }
}
