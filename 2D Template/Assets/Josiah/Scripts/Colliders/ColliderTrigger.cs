using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigger : MonoBehaviour
{
    public event EventHandler OnPlayerEnterTrigger;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if object has the Player tag then check if it's inside the collider or not
        if (collider.CompareTag("Player"))
        {
            Player_Movement player = collider.GetComponent<Player_Movement>();
            if (player != null)
            {
                //Player inside trigger area
                Debug.Log("Player inside trigger");
                OnPlayerEnterTrigger?.Invoke(this, EventArgs.Empty);
            }
        }

    }
}