using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthHeartBar : MonoBehaviour
{
    public event Action OnPlayerDamaged, OnPlayerDeath, OnPlayerHeal;
    public float playerHealth = 6, playerMaxHealth = 6;
    public GameObject heartPrefab;
    public KeyCode healthUp, healthDown;

    public Shake shake;

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
        //shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(healthUp))
        //{
        //    playerHealth++;
        //    OnPlayerHeal?.Invoke();
        //}
        //if (Input.GetKeyDown(healthDown))
        //{
        //    playerHealth--;
        //    OnPlayerHeal?.Invoke();
        //}
        if (playerHealth > playerMaxHealth)
        {
            playerHealth = playerMaxHealth;
        }
        if (playerHealth <= 0)
        {
            playerHealth = 0;
            SceneManager.LoadScene("You Died");
            Debug.Log("You're Dead");
            OnPlayerDeath?.Invoke();
        }
    }

    public void DrawHearts()
    {
        ClearHearts();

        //Determine how many hearts to make total Based on max health        
        float maxHealthRemainder = playerMaxHealth %2;
        int heartsToMake = (int)((playerMaxHealth / 2) + maxHealthRemainder); //make 5 hearts (2)(2)(1)        

        for(int i = 0; i < heartsToMake; i++)
        {
            CreateEmptyHearts();
        }

        for(int i = 0; i < hearts.Count; i++)
        {
            int heartStatusRemainder = (int)Mathf.Clamp(playerHealth - (i * 2), 0, 2);
            hearts[i].SetHeartImage((HealthHeart.HeartStatus)(heartStatusRemainder));
        }
    }

    public void CreateEmptyHearts()
    {
        GameObject newHeart = Instantiate(heartPrefab);
        newHeart.transform.SetParent(transform);

        HealthHeart heartComponent = newHeart.GetComponent<HealthHeart>();
        heartComponent.SetHeartImage(HealthHeart.HeartStatus.Empty);
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
        Debug.Log($"Damage taken {amount}");
        shake.CamShake();
        //GetComponent()
    }

    public void HealDamage(float amount)
    {
        playerHealth += amount;
        OnPlayerHeal?.Invoke();
    }
}