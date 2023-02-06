using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public int maxHealth = 100;
    private int currentHealth;
    public AudioSource _DieSound;


    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <=0)
        {
            Die();
            _DieSound.Play();
        }


    }

    void Die()
    {
        Debug.Log("Dead");
    }

}
