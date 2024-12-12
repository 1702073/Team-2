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
    [SerializeField] private EnemyGeneral[] enemies;

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
        state = State.Active;

        foreach (EnemyGeneral enemy in enemies)
        {
            enemy.Spawn();
        }
    }


}
