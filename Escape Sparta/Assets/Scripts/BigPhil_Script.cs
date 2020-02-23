using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BigPhil_Script : MonoBehaviour
{
    public bool philAwake = false;
    Animator anim;
    float speed = 4.5f;
    public Transform target;
    CanvasGroup endText;  
    Player_Movement player_movement;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        endText = GameObject.FindWithTag("Finish").GetComponent<CanvasGroup>();       
        player_movement = GameObject.FindWithTag("Player").GetComponent<Player_Movement>();
    }

   
    void Update()
    {
        if (philAwake == true)
        {
            anim.SetBool("IsAwake", true);
            transform.LookAt(target);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == target)
        {
            endText.alpha = 1f;
            player_movement.isDead = true;
            Invoke("EndGame", 3f);


        }
    }
    void EndGame()
    {
        SceneManager.LoadScene(0);
    }

  
}
