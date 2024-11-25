using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private void Update()
    {
        // If the distance between the enemy and the player is less than or equal to one, then it will attack
        if (Vector2.Distance(transform.position, gameObject.transform.position) <= 1)
        {
            Attack();
        }
    }

    public void Attack()
    {
        //Spawn a circle hitbox and sees what it hit
        var hit = Physics2D.CircleCast(transform.position + Vector3.up, 1, Vector2.zero);

        // See if it hit the player
        if (hit.collider.CompareTag("Player"))
        {
            // Attacks the player
            hit.collider.GetComponent<Player>().health -= 1;
        }
    }
}
