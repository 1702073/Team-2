using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int health = 3;

    public LayerMask AttackLayer;

    private void Update()
    {
        // If the distance between the enemy and the player is less than or equal to one, then it will attack
        if (Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) <= 1)
        {
            Attack();
        }
    }

    public void Attack()
    {
        //Spawn a circle hitbox and sees what it hit
        var hit = Physics2D.CircleCast(transform.position + Vector3.up, 1, Vector2.zero, 0, AttackLayer);

        // See if it hit the player
        if (hit.collider.CompareTag("Player"))
        {
            // Attacks the player
            hit.collider.GetComponent<PlayerTest>().health -= 1;
        }
    }
}