using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform waypointParent;
    public float moveSpeed = 2f;
    public float stoppingDistance = 1f;

    public Transform[] waypoints;
    private int currentIndex = 1;
    //This makes the array start at index 1, as opposed to 0, since Unity will include the Waypoint Parent's transform value as index 0

    private NavMeshAgent agent;
    void Start()
    {
        waypoints = waypointParent.GetComponentsInChildren<Transform>();
        //Tells the script to populate the 'waypoints' array with the Transform values from the children objects of Waypoint Parent (including the parent itself, unfortunately)
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
        
    }

    void Patrol()
        //We've created a function here that we can then make run in other parts of this code, as we do in Update above.
        //It's a void, which means that it's a function that doesn't return any resultant data.
    {
        //1 - Get current waypoint
        Transform point = waypoints[currentIndex];
        //This defines 'point' as a variable of type Transform,
        //We could write waypoints[1], but then this would be static, not dynamic, so we write currentIndex

        //2 - Get distance to waypoint
        float distance = Vector3.Distance(transform.position, point.position);
        //Vector3.Distance is a unity function calculating the distance between the first and second elements of the brackets.
        //'transform.position refers to the transform values of the attached object, point.position refers to the currentIndex waypoint we defined above

        //3 - If close to waypoint 
        if(distance < stoppingDistance) 
        {
            //4 - then switch to next waypoint
            currentIndex++;
            //Add one to the index
                if (currentIndex >= waypoints.Length)
                {
                currentIndex = 1;
                }
            //Checks if the next index the function is checking is beyond the range of our waypoints array, if it is, then it resets the current waypoint toWaypoint (0)
        }


        //5 - Translate enemy to waypoint
        //transform.position = Vector3.MoveTowards(transform.position, point.position, moveSpeed * Time.deltaTime);
        //Vector3.MoveTowards is a Unity function that moves the position of the attached object (first element) to a target position (second element) at a specified speed (third element) 

        //Our Newer, Sexier 5 - Tell NavMeshAgent its destination
        agent.SetDestination(point.position);
    }
}
