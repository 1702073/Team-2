using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [SerializeField] private Transform enemyTransform;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartBattle();
    }

    private void StartBattle()
    {
        Debug.Log("StartBattle");
        enemyTransform.GetComponent<EnemyGeneral>().Spawn();
    }
}
