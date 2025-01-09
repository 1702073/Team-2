using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event EventHandler OnPlayerEnterTrigger;
    public static int enemiesActivated;

    //public void EndGame()
    //{

    //}

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if object has the Player tag then check if it's inside the collider or not
        if (collider.CompareTag("Player"))
        {
            Player_Movement player = collider.GetComponent<Player_Movement>();
            if (player != null)
            {
                //Player inside trigger area
                Debug.Log("Player inside trigger, press F");
                OnPlayerEnterTrigger?.Invoke(this, EventArgs.Empty);

                if (player != null && enemiesActivated == 1 && Input.GetKey(KeyCode.E))
                {
                    Debug.Log("Game Over");
                    //EndGame();
                }
            }
        }
    }
}
