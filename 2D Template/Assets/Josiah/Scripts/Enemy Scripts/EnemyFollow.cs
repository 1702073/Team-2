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

    public void EnemyFreeze()
    {
        isStunned = true;

        speed = 0;
        Invoke(nameof(ResetEnemySpeed), 3);
    }
    public void EnemyStun()
    {
        isStunned = true;

        speed = baseSpeedStored * 0.5f;
        Invoke(nameof(ResetEnemySpeed), 3);
    }

    public void ResetEnemySpeed()
    {
        Debug.Log("not brrrr");
        isStunned = false;
        speed = baseSpeedStored;
    }

    public void EnemySlow()
    {
        isSlowed = true;
        if (effectTime > 0)
        {
            speed = baseSpeedStored * 0.5f;
        }
        if (effectTime <= 0)
        {
            isSlowed = false;
            speed = baseSpeedStored;
        }
    }
}

