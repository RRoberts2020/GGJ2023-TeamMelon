using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClicks : MonoBehaviour
{
   public void PlayGame()
   {
        SceneManager.LoadScene("Level Scene");
   }

}
