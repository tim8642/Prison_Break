using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Officer_Movement : MonoBehaviour
{

    public NavMeshAgent nav;
    GameObject player;
    Transform playertransform;
    Animator anim;

    public Transform[] waypoints;
    public bool turnNavOn;
    public int currentWayPointIndex;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        anim = GetComponent<Animator>();
        playertransform = player.transform;
        nav.speed = 3;
        anim.SetBool("IsRunning", true);
        nav.SetDestination(waypoints[0].position);
    }

    
    void Update()
    {
        if (turnNavOn == true)
        {
            nav.SetDestination(playertransform.position);
            anim.SetBool("IsRunning", true);
        }
        else
        {
            if(nav.remainingDistance < nav.stoppingDistance)
            {
                currentWayPointIndex = (currentWayPointIndex + 1) % waypoints.Length;
                nav.SetDestination(waypoints[currentWayPointIndex].position);
                anim.SetBool("IsRunning", true);

            }
            
        }
       
        
    }
}
