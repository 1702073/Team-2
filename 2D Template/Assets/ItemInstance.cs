using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInstance : MonoBehaviour
{
    public Loot loot;

    public void AssignLoot(Loot newloot)
    {
        loot = newloot;
        GetComponent<SpriteRenderer>().sprite = loot.lootSprite;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
