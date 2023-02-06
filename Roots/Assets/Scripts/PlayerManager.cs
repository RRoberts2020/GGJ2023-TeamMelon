using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public GameObject player;

    #region [Varibles]

    // int
    public int playerHealth;

    // bool
    public bool isPlayerDamaged;

    public bool isPlayerDead;

    //Player buffs?

    //used for checkpoint system
    private LevelManager levelManager;

    public AudioSource _playerhurtsound;
    public AudioSource _playerdeadsound;

    #endregion

    // Start is called before the first frame update
    public void Start()
    {
        //checkpoint testing
        levelManager = GameObject.FindGameObjectWithTag("Level Manager").GetComponent<LevelManager>();
        transform.position = levelManager.lastPlayerPos;

        playerHealth = 3;

        isPlayerDead = false;
    }

    // Update is called once per frame
    public void Update()
    {
        if (isPlayerDamaged == true)
        {
            playerHealth = -1;
            _playerhurtsound.Play();
        }

        if (playerHealth == 0)
        {
            isPlayerDead = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            _playerdeadsound.Play();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            playerHealth--;
        }
    }

   

}
