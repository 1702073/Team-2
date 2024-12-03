using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class HealthHeartBar : MonoBehaviour
{
    public GameObject heartPrefab;
    public PlayerStats playerHealth;
    public PlayerStats playerMaxHealth;
    List<HealthHeart> hearts = new List<HealthHeart>();

    public void DrawHearts()
    {
        ClearHearts();

        //Determine how many hearts to make total
        //Based on max health
        float maxHealthRemainder = playerHealth.playerMaxHealth %2;
        //int heartsToMake = ((int)(playerHealth.playerMaxHealth / 2) + maxHealthRemainder);
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
}
