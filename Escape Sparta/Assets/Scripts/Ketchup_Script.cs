using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ketchup_Script : MonoBehaviour
{
    GameObject player;
    Player_Stats player_stats;
    BigPhil_Script phil;
    GameObject door;
    CanvasGroup philText;
   
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        player_stats = player.GetComponent<Player_Stats>();
        phil = GameObject.FindWithTag("Phil").GetComponent<BigPhil_Script>();
        door = GameObject.FindWithTag("Door");
        philText = GameObject.FindWithTag("philMessage").GetComponent<CanvasGroup>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            player_stats.gotKeptchup = true;
            phil.philAwake = true;
            Destroy(door);
            gameObject.SetActive(false);
            philText.alpha = 1f;
            Invoke("StopMessage", 4f);


        }

    }

    void StopMessage()
    {
        philText.alpha = 0f;
        Destroy(gameObject);
    }
}
