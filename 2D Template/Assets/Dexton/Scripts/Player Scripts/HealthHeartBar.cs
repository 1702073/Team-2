using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class HealthHeartBar : MonoBehaviour
{
    public GameObject heartPrefab;

    public event Action OnPlayerDamaged;
    public event Action OnPlayerDeath;
    public event Action OnPlayerHeal;

    public KeyCode healthUp;

    public float playerHealth = 6;
    public float playerMaxHealth = 6;
    List<HealthHeart> hearts = new List<HealthHeart>();

    private void OnEnable()
    {
        OnPlayerDamaged += DrawHearts;
        OnPlayerHeal += DrawHearts;

    }
    private void OnDisable()
    {
        OnPlayerDamaged -= DrawHearts;
        OnPlayerHeal -= DrawHearts;
    }


    private void Start()
    {
       DrawHearts ();
    }

    private void Update()
    {
        if (Input.GetKeyDown(healthUp))
        {
            playerHealth++;
            OnPlayerHeal?.Invoke();
        }

        if (playerHealth > playerMaxHealth)
        {
            playerHealth = playerMaxHealth;
        }

        if (playerHealth <= 0)
        {
            playerHealth = 0;
            SceneManager.LoadScene("Title");
            Debug.Log("You're Dead");
            OnPlayerDeath?.Invoke();
        }
    }


    public void DrawHearts()
    {
        ClearHearts();

        //Determine how many hearts to make total
        //Based on max health
        float maxHealthRemainder = playerMaxHealth %2; // 5/2=3 remainder1
        int heartsToMake = (int)((playerMaxHealth / 2) + maxHealthRemainder);
        //make 5 hearts (2)(2)(1)

        for(int i = 0; i < heartsToMake; i++)
        {
            CreateEmptyHearts();
        }

        for(int i = 0; i < hearts.Count; i++)
        {
            int heartStatusRemainder = (int)Mathf.Clamp(playerHealth - (i * 2), 0, 2);
            hearts[i].SetHeartImage((HeartStatus)(heartStatusRemainder));
        }
    }

    public void CreateEmptyHearts()
    {
        GameObject newHeart = Instantiate(heartPrefab);
        newHeart.transform.SetParent(transform);

        HealthHeart heartComponent = newHeart.GetComponent<HealthHeart>();
        heartComponent.SetHeartImage(HeartStatus.Empty);
        hearts.Add(heartComponent);
    }

    public void ClearHearts()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        hearts = new List<HealthHeart> ();
    }

    public void TakeDamage(float amount)
    {
        playerHealth -= amount;
        OnPlayerDamaged?.Invoke();        
    }
}
