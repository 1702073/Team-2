using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    private enum State
    {
        Idle,
        Active,
    }
    [SerializeField] private Transform enemyTransform;

    private State state;

    private void Awake()
    {
        state = State.Idle;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (state == State.Idle)
        {
            StartBattle();
        }
    }

    private void StartBattle()
    {
        Debug.Log("StartBattle");
        enemyTransform.GetComponent<EnemyGeneral>().Spawn();
        state = State.Active;
    }
}
