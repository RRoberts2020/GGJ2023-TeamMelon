using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject endGamePanel;
    private LevelManager levelManager;

    void Start()
    {
        endGamePanel.SetActive(false);
        levelManager = GameObject.FindGameObjectWithTag("Level Manager").GetComponent<LevelManager>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Player")
        {
            endGamePanel.SetActive(true);
            Debug.Log("In trigger");
            levelManager.lastPlayerPos = transform.position;

        }
       
    }
}
