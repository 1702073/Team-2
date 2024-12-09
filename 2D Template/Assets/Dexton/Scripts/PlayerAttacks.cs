using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    public LayerMask AttackLayer;

    public float cooldown;
    public bool attackReady = true;

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }

    } 

    public void Attack()
    {
        // Spawn a circle hitbox and sees what it hit
        var hit = Physics2D.CircleCast(transform.position + Vector3.up, 1, Vector2.zero, 0, AttackLayer);

        // See if it hit the player
        if (hit&&hit.collider.CompareTag("Enemy"))
        {
            // Attacks the player
            hit.collider.GetComponent<EnemyGeneral>().enemyHealth -= 1;
        }

        attackReady = false;
        // Forces the enemy to wait before it can attack again
        //Invoke(nameof(ResetAttack), cooldown);
    }

    //private void ResetAttack()
    //{
    //    attackReady = true;
    //}
}