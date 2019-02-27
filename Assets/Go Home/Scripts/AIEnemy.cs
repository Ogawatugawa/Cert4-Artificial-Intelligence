using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]

public class AIEnemy : MonoBehaviour
{
    public Transform target;
    //Creates Transform variable called 'target'
    private NavMeshAgent agent;
    //Creates variable 'agent' which we'll reference to the NavMeshComponent
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //This tells the script that 'agent' is referring to the NavMeshAgent attached to this object
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
        //Every frame the script updates the destination of NavMeshAgent
    }
}
