using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public Animator enemyAnimator;

    Vector2 movement;

    private Transform target;

    private EnemyGeneral enemyGeneral;

    private Rigidbody2D rb2D;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        enemyGeneral = GetComponent<EnemyGeneral>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        switch (enemyGeneral.state)
        {
            case EnemyGeneral.State.Idle:

                break;

            case EnemyGeneral.State.Active:
                if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
                {
                    rb2D.velocity = Vector2.Lerp(rb2D.velocity, (target.position - transform.position).normalized * speed, Time.deltaTime);
                }

                movement = target.position - transform.position;

                enemyAnimator.SetFloat("Horizontal", movement.x);
                enemyAnimator.SetFloat("Vertical", movement.y);
                enemyAnimator.SetFloat("Speed", movement.sqrMagnitude);

                break;
        }
    }
}

