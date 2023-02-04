using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{


    #region [Varibles]

    // GameObjects

    public GameObject player;

    public GameObject HP1;
    public GameObject HP1_Empty;
    public GameObject HP2;
    public GameObject HP2_Empty;
    public GameObject HP3;
    public GameObject HP3_Empty;

    // int
    public int playerHealth;

    public int countDownTick;

    // bool
    public bool isPlayerDamaged;

    public bool isPlayerDead;

    //Player buffs?

    //used for checkpoint system
    private LevelManager levelManager;


    #endregion

    // Start is called before the first frame update
    public void Start()
    {
        //checkpoint testing
        levelManager = GameObject.FindGameObjectWithTag("Level Manager").GetComponent<LevelManager>();
        transform.position = levelManager.lastPlayerPos;

        playerHealth = 3;

        isPlayerDead = false;

        countDownTick = 0;
    }

    // Update is called once per frame
    public void Update()
    {

        // Damage subset
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerHealth--;
            Debug.Log("Check damage");
        }


        //Health

        if (playerHealth == 3)
        {
            HP1.SetActive(true);
            HP1_Empty.SetActive(false);
            HP2.SetActive(true);
            HP2_Empty.SetActive(false);
            HP3.SetActive(true);
            HP3_Empty.SetActive(false);
        }

        if (playerHealth == 2)
        {
            HP3.SetActive(false);
            HP3_Empty.SetActive(true);
        }

        if (playerHealth == 1)
        {
            HP2.SetActive(false);
            HP2_Empty.SetActive(true);
        }

        // Dead player

        if (playerHealth == 0)
        {
            HP1.SetActive(false);
            HP1_Empty.SetActive(true);

            isPlayerDead = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            playerHealth--;
        }
    }

   

}
