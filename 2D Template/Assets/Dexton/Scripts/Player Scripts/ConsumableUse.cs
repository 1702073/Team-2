using UnityEngine;
using static Player_Items;

public class ConsumableUse : MonoBehaviour
{
    public HealthHeartBar healthHeartBar;
    public Consumable consumableType;
    public Player_Items player_Items;
    public IsHolding isHolding;

    public void Start()
    {
        healthHeartBar = FindObjectOfType<HealthHeartBar>();
        player_Items = FindObjectOfType<Player_Items>();
    }

    public enum Consumable
    {
        Half_Heart = 0,
        Full_Heart = 1,
        Salt = 2,
        Bottle = 3
    }

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && consumableType == Consumable.Half_Heart)
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
            isHolding = IsHolding.Salt;
            Destroy(gameObject);
            player_Items.isHolding = IsHolding.Salt;
        }
        else if (collision.gameObject.CompareTag("Player") && consumableType == Consumable.Bottle)
        {
            isHolding = IsHolding.Bottle;
            Destroy(gameObject);
            player_Items.isHolding = IsHolding.Bottle;
        }
    }
}
