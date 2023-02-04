using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Leaderboard : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshProUGUI gen1Text;
    public TextMeshProUGUI gen2Text;
    public TextMeshProUGUI gen3Text;
    public TextMeshProUGUI gen4Text;

    public int previousRunScore = 0;
    public int topScore = 4;
    public int secondScore = 3;
    public int thirdScore = 2;
    public int fourthScore = 1;





    void Start()
    {
        gen1Text.text = "Top Highscore: " + PlayerPrefs.GetInt("Highscore", topScore).ToString();
        gen2Text.text = "Second Highscore: " + PlayerPrefs.GetInt("Highscore", secondScore).ToString();
        gen3Text.text = "Third Highscore: " + PlayerPrefs.GetInt("Highscore", thirdScore).ToString();
        gen4Text.text = "Fourth Highscore: " + PlayerPrefs.GetInt("Highscore", fourthScore).ToString();


        Score();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Score()
    {
        PlayerPrefs.SetInt("Top Highscore", topScore);
        gen1Text.text = "Highscore: " + topScore.ToString();

        PlayerPrefs.SetInt("Second Highscore", secondScore);
        gen2Text.text = "Highscore: " + secondScore.ToString();


        PlayerPrefs.SetInt("Second Highscore", thirdScore);
        gen3Text.text = "Highscore: " + thirdScore.ToString();


        PlayerPrefs.SetInt("Second Highscore", 1);
        gen4Text.text = "Highscore: " + fourthScore.ToString();
    }


    public void addScore()
    {
        previousRunScore++;

        if (previousRunScore > PlayerPrefs.GetInt("Top Highscore", topScore))
        {
            PlayerPrefs.SetInt("Top Highscore", topScore);
            gen1Text.text = "Highscore: " + topScore.ToString();

            Debug.Log("Set new top score");
            Debug.Log(topScore);
        }

        if(previousRunScore > secondScore && previousRunScore < topScore)
        {
            PlayerPrefs.SetInt("Second Highscore", secondScore);
            gen2Text.text = "Highscore: " + secondScore.ToString();

            Debug.Log("Set new second score");
        }

        if (previousRunScore > thirdScore && previousRunScore < secondScore)
        {
            PlayerPrefs.SetInt("Third Highscore", thirdScore);
            gen3Text.text = "Highscore: " + thirdScore.ToString();

            Debug.Log("Set new third score");
        }

        if (previousRunScore > fourthScore && previousRunScore < thirdScore)
        {
            PlayerPrefs.SetInt("Fourth Highscore", fourthScore);
            gen4Text.text = "Highscore: " + fourthScore.ToString();

            Debug.Log("Set new fourth score");
        }
    }


}
