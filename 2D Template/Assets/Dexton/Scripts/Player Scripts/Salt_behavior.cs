using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salt_behavior : MonoBehaviour
{
    public LayerMask EnemyLayer;
    public float radius;

    // Update is called once per frame
    void Update()
    {
        var hits = Physics2D.CircleCastAll(transform.position, radius, Vector2.zero, 0, EnemyLayer);
        foreach (RaycastHit2D hit in hits)
        {
            Debug.Log("djhfkshdufsdhf");
            hit.collider.GetComponent<EnemyFollow>().EnemyFreeze();
        }
    }
}
