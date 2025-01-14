using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static GameManager;

public class EnemyGeneral : MonoBehaviour
{
    public AudioClip hitNoise;

    public Animator enemyAttackAnimation;

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
        // Adds to the hidden number enemiesDestroyed which I use as a condition for the game to end
        enemiesDestroyed++;
    }

    private void Start()
    {
        // The enemy starts in idle until it is activated by whatever trigger it is assigned to
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

                    // Forces the enemy to wait before it can attack again
                    Invoke(nameof(ResetAttack), cooldown);
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
        // Moves the enemy to whatever position it is assigned to
        transform.position = (enemyPosition);
        // Activates enemy so that it moves and attacks
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

            // Plays the attack animation
            enemyAttackAnimation.SetFloat("Horizontal", enemyPosition.x);
            enemyAttackAnimation.SetFloat("Vertical", enemyPosition.y);
            enemyAttackAnimation.SetTrigger("Attack");

            // Sets the attackReady to false so that it waits for the cooldown
            attackReady = false;

            /* // Plays audio clip named hitNoise when the enemy 
            AudioSource.PlayClipAtPoint(hitNoise, enemyPosition);*/

        }

    }

    // Resets the value to true after the cooldown variable is over
    private void ResetAttack()
    {
        attackReady = true;
    }

    // When the player hits the enemy it takes the variable amount of damage, and it then updates the look of the healthbar
    public void EnemyTakeDamage( int damage)
    {
        enemyAttackAnimation.SetTrigger("Take Damage");
        enemyHealth -= damage;
        healthBar.UpdateHealthBar(enemyHealth, enemyMaxHealth);
    }

    void Death()
    {
        // Gets the lootbag randomizer and then creates loot when the enemy dies
        GetComponent<LootBag>().InstantiateLoot(transform.position);
        // Adds whatever the score value is to the current score
        Score.scoreValue += enemyScore;
        Debug.Log("Enemy defeated");
        // Deletes the enemy
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        // This function allows you to see the circle that the enemy casts when it attacks
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }

}
