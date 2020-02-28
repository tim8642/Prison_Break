using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Student_Movement : MonoBehaviour
{
    public NavMeshAgent nav;
    Animator anim;

    public Transform[] waypoints;  
    public int currentWayPointIndex;
    public bool studentMovement;
    public bool isNowDead;
    


    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        nav.speed = 4;
        anim.SetBool("IsRunning", true);
        anim.speed = 1.3f;
        nav.SetDestination(waypoints[0].position);

    }


    void Update()
    {
        if (isNowDead == true)
        {
           
            nav.speed = 0;
            anim.SetBool("IsRunning", false);
            anim.SetBool("IsDead", true);         
            isNowDead = false;
            
            
        }
        else 
        {
            if (nav.remainingDistance < nav.stoppingDistance)
            {
                currentWayPointIndex = (currentWayPointIndex + 1) % waypoints.Length;
                nav.SetDestination(waypoints[currentWayPointIndex].position);
            }
            


        }



    }

   

}

