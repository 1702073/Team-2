using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Items : MonoBehaviour
{
    public ConsumableUse ConsumableUse;

    // Start is called before the first frame update
    void Start()
    {
        ConsumableUse = FindObjectOfType<ConsumableUse>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
