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
    Transform student;
    bool studentInRange;
    public Transform studentTarget;
    public GameObject studentObject;


   

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        movement = GetComponent<Officer_Movement>();
        student = GameObject.FindWithTag("Student").transform;
        //nav.enabled = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            playerInRange = true;                   
        }
        else if (other.transform == student)
        {
            if (other.GetComponent<Student_Movement>().isNowDead == false)
            {
                             
                Debug.Log("student being triggered");
                studentInRange = true;

                studentTarget = other.gameObject.transform;
                studentObject = other.gameObject;
                
                
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            playerInRange = false;
        }
        //if (other.transform == student)
       // {
       //     studentInRange = false;
            
       // }
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
                    movement.NavOnPlayer = true;
                    //nav.enabled = true;
                }
            }
        }
        else if(studentInRange == true)
        {
            Vector3 direction = studentTarget.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit rayCastHit;

            if (Physics.Raycast(ray, out rayCastHit))
            {
                if (rayCastHit.collider.transform == studentTarget)
                {
                    movement.NavOnStudent = true;
                    
                    //nav.enabled = true;
                }
            }
        }
    }

  

  
}
