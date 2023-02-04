using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector2 lastPlayerPos;
    public GameObject[] playerSprite;
    public int currentPlayerSprite;

    private static LevelManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
       else
        {
            Destroy(gameObject);
        }

    }



}
