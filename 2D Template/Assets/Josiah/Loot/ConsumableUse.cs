using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableUse : MonoBehaviour
{
    public HealthHeartBar healthHeartBar;
    public Consumable consumableType;

    public void Start()
    {
        healthHeartBar = FindObjectOfType<HealthHeartBar>();
    }

    public enum Consumable
    {
        Half_Heart = 0,
        Full_Heart = 1,
        Salt = 2,
        Jar = 3
    }

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && consumableType == 0)
        {
            FindObjectOfType<HealthHeartBar>().HealDamage(1);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Player") && consumableType == Consumable.Full_Heart)
        {
            FindObjectOfType<HealthHeartBar>().HealDamage(2);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Player") && consumableType == Consumable.Salt)
        {

        }
        else if (collision.gameObject.CompareTag("Player") && consumableType == Consumable.Jar)
        {

        }
    }
}
