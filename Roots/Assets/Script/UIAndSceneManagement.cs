using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIAndSceneManagement : MonoBehaviour
{

    #region [Variables]

    // Bool

    PlayerStats isPlayerDeadCheck;

    // States

    public GameObject StartScreen;

    public GameObject MainScreen;

    public GameObject BuffTreeScreen;

    public GameObject ChooseScreen;

    public GameObject GameOverScreen;

    #endregion

    #region [Functions]

    private void Start()
    {
        StartScreen.SetActive(true);
        MainScreen.SetActive(false);
        BuffTreeScreen.SetActive(false);
        ChooseScreen.SetActive(false);
        GameOverScreen.SetActive(false);
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
