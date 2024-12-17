using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Damage : MonoBehaviour
{

    public int damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<HealthHeartBar>().TakeDamage(damage);
        }
    }
}
