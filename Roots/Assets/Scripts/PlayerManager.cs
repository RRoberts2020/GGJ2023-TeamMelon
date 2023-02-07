using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public GameObject player;
    public AudioClip[] playerHurt;

    #region [Varibles]

    // int
    public int playerHealth;

    // bool
    public bool isPlayerDamaged;

    public bool isPlayerDead;

    //Player buffs?

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

        playerHealth = 3;

        isPlayerDead = false;
    }

    // Update is called once per frame
    public void Update()
    {
      

  
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
        Destroy(gameObject);
        isPlayerDead = true;
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }




}
