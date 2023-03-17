using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject[] waypoints; //Fill in the waypoints from unity
    [SerializeField] private float speed = 2f; // Custom Speed
    private int currentWaypointIndex = 0; //Init at Zero

    // Update is called once per frame
    private void Update()
    {
        if(Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position)< .1f) //Check if arrived at waypoint
        {
            currentWaypointIndex++; //Increment Waypoint Index
            {
                if(currentWaypointIndex >= waypoints.Length) //Check if at end of array
                {
                    currentWaypointIndex = 0; //Reset it to 0 (Restart Loop)
                }
            }
        }
        //Move Towards Next Waypoint
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
