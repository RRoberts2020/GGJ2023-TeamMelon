using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public int maxHealth = 100;
    private int currentHealth;
    public AudioClip _DieSound;


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
            
        }


    }

    void Die()
    {
        AudioSource.PlayClipAtPoint(_DieSound, transform.position);
        Destroy(gameObject);
    }

}
