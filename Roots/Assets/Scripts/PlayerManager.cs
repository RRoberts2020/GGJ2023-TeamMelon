using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public GameObject player;
    public AudioClip[] playerHurt;
    public Sprite emptyHearts;
    public Sprite fullHearts;
    public Image[] hearts;


    #region [Varibles]

    // int
    public int playerHealth;
    public int maxHealth;

    // bool
    public bool isPlayerDamaged;
//
    public bool isPlayerDead;


    //used for checkpoint system
    private LevelManager levelManager;

    public AudioSource _playerdeadsound;

    #endregion

    // Start is called before the first frame update
    public void Start()
    {
        //checkpoint testing
        levelManager = GameObject.FindGameObjectWithTag("Level Manager").GetComponent<LevelManager>();
        //transform.position = levelManager.lastPlayerPos;

       

       // isPlayerDead = false;
    }

    // Update is called once per frame
    public void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < playerHealth)
            {
                hearts[i].sprite = fullHearts;
            }
            else
            {
               hearts[i].sprite = emptyHearts;

            }

            if(i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }


        }

  
    }

    public void TakeDamage(int damage)
    {
        playerHealth--;
        AudioSource.PlayClipAtPoint(playerHurt[Random.Range(0, 1)], transform.position);
        if (playerHealth <= 0)
        {
            PlayerDeath();

        }
    }

    public void PlayerDeath()
    {
        
       // isPlayerDead = true;
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }




}
