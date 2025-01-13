using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static GameManager;

public class EnemyGeneral : MonoBehaviour
{
    public GameObject enemyPrefab;

    //public PlayerStats playerHealth;
    public int enemyHealth;

    [SerializeField] private int enemyMaxHealth = 3;

    [SerializeField] FloatingHealthBar healthBar;

    public Vector2 enemyPosition;

    public enum State
    {
        Idle,
        Active,
    }

    public State state;

    public LayerMask AttackLayer;

    public float enemyAttackDamage;
    public float cooldown;
    public bool attackReady = true;
    public float attackDistance;

    public int enemyScore;

    private void OnDestroy()
    {
        enemiesDestroyed++;
    }

    private void Start()
    {
        state = State.Idle;
        healthBar.UpdateHealthBar(enemyHealth, enemyMaxHealth);
    }

    private void Update()
    {
        switch (state)
        {
            case State.Idle:

                break;

            case State.Active:
                healthBar  = GetComponentInChildren<FloatingHealthBar>();

                healthBar.UpdateHealthBar(enemyHealth, enemyMaxHealth);

                // If the distance between the enemy and the player is less than or equal to one, then it will attack
                if ((Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) <= attackDistance) && (attackReady == true))
                {
                    Attack();
                }

                if (enemyHealth <= 0)
                {
                    Death();
                }

                break;
        }
    }

    public void Spawn()
    {
        transform.position = (enemyPosition);
        state = State.Active;
    }

    public void Attack()
    {
        // Spawn a circle hitbox and sees what it hit
        var hit = Physics2D.CircleCast(transform.position, attackDistance, Vector2.zero, 0, AttackLayer);

        // See if it hit the player
        if (hit&&hit.collider.CompareTag("Player"))
        {
            // Attacks the player
            hit.collider.GetComponent<HealthHeartBar>().TakeDamage(enemyAttackDamage);
        }
        
        attackReady = false;

        // Forces the enemy to wait before it can attack again
        Invoke(nameof(ResetAttack), cooldown);
    }

    private void ResetAttack()
    {
        attackReady = true;
    }

    public void EnemyTakeDamage( int damage)
    {
        enemyHealth -= damage;
        healthBar.UpdateHealthBar(enemyHealth, enemyMaxHealth);
    }

    void Death()
    {
        GetComponent<LootBag>().InstantiateLoot(transform.position);
        Score.scoreValue += enemyScore;
        Debug.Log("Enemy defeated");
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }

}
