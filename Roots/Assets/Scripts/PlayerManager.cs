using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    #endregion

    // Start is called before the first frame update
    public void Start()
    {
        playerHealth = 3;

        isPlayerDead = false;
    }

    // Update is called once per frame
    public void Update()
    {
        if (isPlayerDamaged == true)
        {
            playerHealth = -1;
        }

        if (playerHealth == 0)
        {
            isPlayerDead = true;
        }
    }

}
