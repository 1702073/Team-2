using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyGeneral : MonoBehaviour
{
    public GameObject enemyPrefab;

    //public PlayerStats playerHealth;
    public int enemyHealth;

    public Vector2 enemyPosition;

    public LayerMask AttackLayer;

    public float cooldown;
    public bool attackReady = true;

    public int enemyScore;

    private void Update()
    {
        // If the distance between the enemy and the player is less than or equal to one, then it will attack
        if ((Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) <= 1) && (attackReady == true))
        {
            Attack();
        }

        if (enemyHealth <= 0)
        {
            Death();
        }
    }

    public void Spawn()
    {
        transform.position = (enemyPosition);
    }

    public void Attack()
    {
        // Spawn a circle hitbox and sees what it hit
        var hit = Physics2D.CircleCast(transform.position + Vector3.up, 1, Vector2.zero, 0, AttackLayer);

        // See if it hit the player
        if (hit&&hit.collider.CompareTag("Player"))
        {
            // Attacks the player
            hit.collider.GetComponent<HealthHeartBar>().playerHealth -= 1;
        }
        
        attackReady = false;

        // Forces the enemy to wait before it can attack again
        Invoke(nameof(ResetAttack), cooldown);
    }

    private void ResetAttack()
    {
        attackReady = true;
    }

    public void TakeDamage( int damage)
    {
        enemyHealth -= damage;
    }

    void Death()
    {
        GetComponent<LootBag>().InstantiateLoot(transform.position);
        Score.scoreValue += enemyScore;
        Destroy(gameObject);
    }

}
