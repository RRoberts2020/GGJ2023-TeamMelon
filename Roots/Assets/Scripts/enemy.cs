using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public int maxHealth = 100;
    private int currentHealth;
    public AudioClip _DieSound;


    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int enemyAttackDamage = 20;
    public float attackRate = 2f;
    private float nextAttackTime = 0;


    public AudioSource _attackSound;


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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            EnemyAttack();
        }

    }

    void EnemyAttack()
    {
        Debug.Log("Enemy attacked");
        if (Time.time >= nextAttackTime)
        {
            Collider2D[] playerHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);

            foreach (Collider2D player in playerHit)
            {
                Debug.Log("Made it to foreach loop");
                player.GetComponent<PlayerManager>().TakeDamage(enemyAttackDamage);
            }
            _attackSound.Play();
        }

    }

    private void OnDrawGizmosSelected()
    {

        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    void Die()
    {
        AudioSource.PlayClipAtPoint(_DieSound, transform.position);
        Destroy(gameObject);
    }

}
