using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIAndSceneManagement : MonoBehaviour
{

    #region [Variables]

    // int

    public int buffAllocator;

    // Bool

    PlayerManager isPlayerDeadCheck;

    public bool jumpBuff1Bool;

    public bool speedBuff1Bool;

    public bool jumpBuff2Bool;

    public bool speedBuff2Bool;

    public bool jumpBuff3Bool;

    public bool speedBuff3Bool;

    public bool jumpBuff4Bool;

    public bool speedBuff4Bool;

    // States

    public GameObject StartScreen;

    public GameObject MainScreen;

    public GameObject BuffTreeScreen;

    public GameObject ChooseScreen;

    public GameObject GameOverScreen;

    // Gameobject

    public GameObject jumpBuff1;

    public GameObject speedBuff1;

    public GameObject jumpBuff2;

    public GameObject speedBuff2;

    public GameObject jumpBuff3;

    public GameObject speedBuff3;

    public GameObject jumpBuff4;

    public GameObject speedBuff4;

    #endregion

    #region [Functions]

    private void Start()
    {
        StartScreen.SetActive(true);
        MainScreen.SetActive(false);
        BuffTreeScreen.SetActive(false);
        ChooseScreen.SetActive(false);
        GameOverScreen.SetActive(false);

        buffAllocator = 1;

        jumpBuff1Bool = false;

        speedBuff1Bool = false;

        jumpBuff2Bool = false;

        speedBuff2Bool = false;

        jumpBuff3Bool = false;

        speedBuff3Bool = false;

        jumpBuff4Bool = false;

        speedBuff4Bool = false;
}

    private void Update()
    {
        if (isPlayerDeadCheck.isPlayerDead == true)
        {
            GameOverState();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    #endregion

    #region [Start Screen]

    public void PlayScene(string PlayScene)
    {
        SceneManager.LoadScene(PlayScene); //Change it later on to match playable secene name
    }

    #endregion

    #region [Main Screen]

    #endregion

    #region [BuffTree Screen]

    public void BuffUI()
    {

        //Section 1
        if (buffAllocator == 1 && jumpBuff1Bool == true)
        {
            jumpBuff1.SetActive(true);

            speedBuff1.SetActive(false);
        }

        if (buffAllocator == 1 && speedBuff1Bool == true)
        {
            jumpBuff1.SetActive(false);

            speedBuff1.SetActive(true);
        }

        //Section 2
        if (buffAllocator == 2 && jumpBuff2Bool == true)
        {
            jumpBuff2.SetActive(true);

            speedBuff2.SetActive(false);
        }

        if (buffAllocator == 2 && speedBuff2Bool == true)
        {
            jumpBuff2.SetActive(false);

            speedBuff2.SetActive(true);
        }

        //Section 3
        if (buffAllocator == 3 && jumpBuff3Bool == true)
        {
            jumpBuff3.SetActive(true);

            speedBuff3.SetActive(false);
        }

        if (buffAllocator == 3 && speedBuff3Bool == true)
        {
            jumpBuff3.SetActive(false);

            speedBuff3.SetActive(true);
        }

        //Section 4
        if (buffAllocator == 4 && jumpBuff4Bool == true)
        {
            jumpBuff4.SetActive(true);

            speedBuff4.SetActive(false);
        }

        if (buffAllocator == 4 && speedBuff4Bool == true)
        {
            jumpBuff4.SetActive(false);

            speedBuff4.SetActive(true);
        }

    }

    #endregion

    #region [Choose Screen]

    #endregion

    #region [GameOver Screen]


    private void GameOverState()
    {
        if (isPlayerDeadCheck.isPlayerDead == true)
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Change it later on to match build order (String won't work for this part of the code)

            StartScreen.SetActive(false);
            MainScreen.SetActive(false);
            BuffTreeScreen.SetActive(false);
            ChooseScreen.SetActive(false);
            GameOverScreen.SetActive(true);
        }
    }



    #endregion

}
