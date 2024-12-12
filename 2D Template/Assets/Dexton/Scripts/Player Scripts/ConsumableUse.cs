using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableUse : MonoBehaviour
{
    public HealthHeartBar healthHeartBar;
    public Consumable consumableType;

    public void Start()
    {

        healthHeartBar = GetComponent<HealthHeartBar>();
    }

    public enum Consumable
    {
        Half_Heart = 0,
        Full_Heart = 1,
        Salt = 2,
        Jar = 3
    }

    // Start is called before the first frame update
    void OnTriggerEnter()
    {
        if (CompareTag("Player") && consumableType == 0)
        {
            healthHeartBar.playerHealth++;
        }
    }
}
