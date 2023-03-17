using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FriendAI : MonoBehaviour{
    [Header("Pathfinding")]
    private GameObject target;
    public GameObject player;
    public float activeDistance = 50f;
    public float pathUpdateSeconds = 0.5f;

    [Header("Physics")]
    public float speed = 50f;
    public float nextWaypointDistance = 3f;
    public float jumpNodeHeightRequirement = 0.8f;
    public float jumpModifier = 0.3f;
    public float jumpCheckOffset = 0.1f;

    [Header("Custom Behaviour")]
    public bool followEnabled = true;
    public bool jumpEnabled = true;
    public bool directionLookEnabled = true;

    private Path path;
    private int currentWaypoint = 0;
    bool isGrounded = false;
    Seeker seeker;
    Rigidbody2D rb;

    public void Start(){
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, pathUpdateSeconds);
    }

    private void FixedUpdate(){
        if(/*TargetInDistance() &&*/ followEnabled) PathFollow();

        if (!TargetInDistance()) {
            speed = 0f;
        } else {
            speed = 200f;
        }
    }

    private void UpdatePath(){
        target = GameObject.FindGameObjectWithTag("Therapist");
        if(followEnabled /*&& TargetInDistance()*/ && seeker.IsDone()) seeker.StartPath(rb.position, target.transform.position, OnPathComplete);
    }

    private void PathFollow(){
        if(path == null) return;
        if(currentWaypoint >= path.vectorPath.Count) return;

        isGrounded = Physics2D.Raycast(transform.position, -Vector3.up, GetComponent<Collider2D>().bounds.extents.y + jumpCheckOffset);

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        if(jumpEnabled && isGrounded){
            if(direction.y > jumpNodeHeightRequirement) rb.AddForce(Vector2.up * speed * jumpModifier);
        }

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if(distance < nextWaypointDistance) currentWaypoint++;

        if(directionLookEnabled){
            if(rb.velocity.x > 0.05f) transform.localScale = new Vector3(-1f * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            else if(rb.velocity.x < -0.05f) transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    private bool TargetInDistance(){
        return Vector2.Distance(transform.position, player.transform.position) < activeDistance;
    }

    private void OnPathComplete(Path p){
        if(!p.error){
            path = p;
            currentWaypoint = 0;
        }
    }

}
