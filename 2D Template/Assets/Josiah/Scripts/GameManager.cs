using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event EventHandler OnPlayerEnterTrigger;
    
    public static int enemiesDestroyed;

    public bool isInCollider;

    //public void EndGame()
    //{

    //}

    public void Update()
    {
        if (isInCollider == true && enemiesDestroyed == 19 && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Game Over");
            //EndGame();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            isInCollider = true;
            Player_Movement player = collider.GetComponent<Player_Movement>();
            if (player != null)
            {
                //Player inside trigger area
                Debug.Log("Player inside trigger, press E");
                OnPlayerEnterTrigger?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            isInCollider = false;
        }
    }

    //private void OnTriggerStay2D(Collider2D collider)
    //{
    //    // Check if object has the Player tag then check if it's inside the collider or not
    //    if (collider.CompareTag("Player"))
    //    {
    //        Player_Movement player = collider.GetComponent<Player_Movement>();
    //    }
    //}
}
