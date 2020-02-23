using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Officer_Movement : MonoBehaviour
{

    public NavMeshAgent nav;
    GameObject player;
    Transform playertransform;
    Animator anim;
    CanvasGroup endText;

    public Transform[] waypoints;
    public bool turnNavOn;
    public int currentWayPointIndex;
    Player_Movement player_movement;
    

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        anim = GetComponent<Animator>();
        playertransform = player.transform;
        nav.speed = 3;
        anim.SetBool("IsWalking", true);
        anim.speed = 1.3f;
        nav.SetDestination(waypoints[0].position);
        endText = GameObject.FindWithTag("Finish").GetComponent<CanvasGroup>();
        player_movement = player.GetComponent<Player_Movement>();
    }

    
    void Update()
    {
        if (turnNavOn == true)
        {
            nav.SetDestination(playertransform.position);
            anim.SetBool("IsWalking", false);
            anim.SetBool("IsRunning", true);
            anim.speed = 1f;
            nav.speed = 5.5f;

            if (nav.remainingDistance < nav.stoppingDistance)
            {
                Debug.Log("hit");
                player_movement.isDead = true;
                endText.alpha = 1f;
                Invoke("EndGame", 3f);
            }
        }
        else
        {
            if(nav.remainingDistance < nav.stoppingDistance)
            {
                currentWayPointIndex = (currentWayPointIndex + 1) % waypoints.Length;
                nav.SetDestination(waypoints[currentWayPointIndex].position);
                

            }
            
        }
       
        
    }

    void EndGame()
    {
        SceneManager.LoadScene(0);
    }
}
