using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Items : MonoBehaviour
{
    public enum IsHolding
    {   
        Nothing = 0,
        Salt = 1,
        Bottle = 2
    }

    public IsHolding isHolding;
    private GameObject Bottle;
    private GameObject Salt;

    // Start is called before the first frame update
    void Start()
    {
        Salt = GameObject.FindGameObjectWithTag("Salt");
        Bottle = GameObject.FindGameObjectWithTag("Bottle");
    }

    // Update is called once per frame
    void Update()
    {
        if (isHolding == IsHolding.Nothing)
        {
            Salt.SetActive(false);
            Bottle.SetActive(false);
        }
        else if(isHolding == IsHolding.Salt)
        {
            Salt.SetActive(true); ;
            Bottle.SetActive(false);
        }
        else if (isHolding == IsHolding.Bottle)
        {
            Salt.SetActive(false); ;
            Bottle.SetActive(true);
        } 
    }
}
