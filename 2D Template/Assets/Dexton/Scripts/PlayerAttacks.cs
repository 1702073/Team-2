using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    public LayerMask AttackLayer;

    public float cooldown;
    public bool attackReady = true;

    public float distance;
    public float radius;

    private void Update()
    {


        if (Input.GetMouseButtonDown(0) && attackReady == true)
        {
            Attack();
        }

    } 

    public void Attack()
    {
        // Spawn a circle hitbox and sees what it hit
        var hit = Physics2D.CircleCast(GetAttackSpot(), radius, Vector2.zero, 0, AttackLayer);

        // See if it hit the player
        if (hit&&hit.collider.CompareTag("Enemy"))
        {
            // Attacks the player
            hit.collider.GetComponent<EnemyGeneral>().enemyHealth -= 1;
        }

        attackReady = false;
        // Forces the enemy to wait before it can attack again
        Invoke(nameof(ResetAttack), cooldown);
    }

    private Vector2 GetAttackDirection()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = (mousePos - (Vector2)transform.position).normalized * distance;

        return direction;
    }

    private Vector2 GetAttackSpot()
    {
        return transform.position + (Vector3)GetAttackDirection();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)GetAttackDirection());
        Gizmos.DrawWireSphere(GetAttackSpot(), radius);
    }


    private void ResetAttack()
    {
        attackReady = true;
    }
}