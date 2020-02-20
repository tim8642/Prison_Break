using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Observer : MonoBehaviour
{
    Transform player;
    bool playerInRange;
    NavMeshAgent nav;
    Officer_Movement movement;


    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        movement = GetComponent<Officer_Movement>();
        //nav.enabled = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            playerInRange = true;
           
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            playerInRange = false;
        }
    }



  

    
    void Update()
    {
        if (playerInRange == true)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit rayCastHit;

            if (Physics.Raycast(ray, out rayCastHit))
            {
                if (rayCastHit.collider.transform == player)
                {
                    movement.turnNavOn = true;
                    //nav.enabled = true;
                }
            }
        }
    }
}
