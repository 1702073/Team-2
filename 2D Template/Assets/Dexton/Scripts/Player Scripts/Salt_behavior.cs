using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salt_behavior : MonoBehaviour
{
    public LayerMask EnemyLayer;
    public float radius;
    public float freezeTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var hit = Physics2D.CircleCast(transform.position, radius, Vector2.zero, 0, EnemyLayer);
        if (hit && hit.collider.CompareTag("Enemy"))
        {
            // Attacks the enemy
            //hit.collider.GetComponent<EnemyGeneral>().EnemyTakeDamage(1);
            //hit.rigidbody.AddForce(GetAttackDirection(), ForceMode2D.Impulse);
        }
    }
}
