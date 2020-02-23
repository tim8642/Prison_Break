using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Detection : MonoBehaviour
{
    Transform enemyTransform;
    Transform playerTransform;
    Transform self;

    void Start()
    {
        enemyTransform = GameObject.FindWithTag("Enemy").transform;
        playerTransform = GameObject.FindWithTag("Player").transform;
        self = GetComponent<Transform>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == enemyTransform)
        {
            Debug.Log("hit");
        }
    }

   
    void Update()
    {
        self.position = playerTransform.position;
    }
}
