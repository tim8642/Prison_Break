using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
   
    float h = 0f;
    float v = 0f;
    float tspeed = 10;
    public float speed = 3;
    Animator anim;
    Rigidbody playerRigidbody;
    Vector3 target;
    Vector3 movement;
    

    FloatingJoystick movementjoystick;

    void Start()
    {
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        movementjoystick = GameObject.FindGameObjectWithTag("GameController").GetComponent<FloatingJoystick>();
    }

    void FixedUpdate()
    {
        if(movementjoystick.canmove == true)
        {
            //float h = Input.GetAxis("Horizontal");
            //float v = Input.GetAxis("Vertical");
            h = movementjoystick.Horizontal;
            v = movementjoystick.Vertical;
        }
        else
        {
            h = 0f;
            v = 0f;
        }

    
        float step = tspeed * Time.deltaTime;
        Turning(step);
        Animating(h, v); 

    }


    void Turning(float step)
    {
        target = Vector3.RotateTowards(transform.forward, movement, step, 0.0f);
        transform.rotation = Quaternion.LookRotation(target);


    }
    void OnAnimatorMove()
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);

       
    }

    void Animating(float h, float v)
    {
        if (h != 0f || v != 0f)
        {
            anim.SetBool("IsRunning", true);
            anim.speed = 1.2f;
        }
        else
        {
            anim.SetBool("IsRunning", false);
           // anim.speed = 1f;
        }
    }
}
