using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End_Game : MonoBehaviour
{
    public GameObject player;
    CanvasGroup endText;
    GameObject door;

    void Start()
    {
        endText = GameObject.FindWithTag("Exit").GetComponent<CanvasGroup>();
        door = GameObject.FindWithTag("Door");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            Debug.Log("game ended");
            endText.alpha = 1f;
            door.SetActive(true);
            Invoke("EndGame", 5f);
        }
    }

 

    void EndGame()
    {
      SceneManager.LoadScene(0);
    }
}
