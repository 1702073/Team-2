using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public Animator enemyAnimator;

    public float effectTime;
    private float baseSpeedStored;

    Vector2 movement;

    private Transform target;

    private EnemyGeneral enemyGeneral;

    private Rigidbody2D rb2D;

    public bool isStunned;
    public bool isSlowed;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        enemyGeneral = GetComponent<EnemyGeneral>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        baseSpeedStored = speed;
    }

    private void Update()
    {
        if (isStunned == true)
        {
            effectTime -= Time.deltaTime;
            EnemyFreeze();
        }
        if (isSlowed == true)
        {
            effectTime -= Time.deltaTime;
            EnemyFreeze();
        }

        switch (enemyGeneral.state)
        {
            case EnemyGeneral.State.Idle:

                break;

            case EnemyGeneral.State.Active:
                if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
                {
                    rb2D.linearVelocity = Vector2.Lerp(rb2D.linearVelocity, (target.position - transform.position).normalized * speed, Time.deltaTime);
                }

                movement = target.position - transform.position;

                enemyAnimator.SetFloat("Horizontal", movement.x);
                enemyAnimator.SetFloat("Vertical", movement.y);
                enemyAnimator.SetFloat("Speed", movement.sqrMagnitude);

                break;
        }
    }

    public void EnemyFreeze()
    {
        isStunned = true;

        speed = 0;
        Invoke(nameof(ResetEnemySpeed), 3);
    }

    public void EnemySlow()
    {
        isStunned = true;

        speed = baseSpeedStored * 0.5f;
        Invoke(nameof(ResetEnemySpeed), 8);
    }

    public void ResetEnemySpeed()
    {
        isStunned = false;
        speed = baseSpeedStored;
    }
}

