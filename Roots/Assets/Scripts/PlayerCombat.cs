using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int playerAttackDamage = 20;
    public float attackRate = 2f;
    private float nextAttackTime = 0;

    public LayerMask enemyLayers;

    public AudioSource _attackSound;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Attack();
                _attackSound.Play();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        else
        {

        }





    }

 
    void Attack()
    {
        Collider2D[] enemiesHit =  Physics2D.OverlapCircleAll(attackPoint.position,attackRange, enemyLayers);

        foreach(Collider2D enemy in enemiesHit)
        {
            enemy.GetComponent<enemy>().TakeDamage(playerAttackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {

        if(attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
