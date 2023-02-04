using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{

    public GameObject endGamePanel;


    // Start is called before the first frame update
    void Start()
    {
        endGamePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            endGamePanel.SetActive(true);
            Debug.Log("In trigger");
        }

    }
}
