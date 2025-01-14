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

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Salt");
        GameObject.FindGameObjectWithTag("Bottle");
    }

    // Update is called once per frame
    void Update()
    {
        if (isHolding == IsHolding.Nothing)
        {
            GameObject.FindGameObjectWithTag("Salt").SetActive(false);
            GameObject.FindGameObjectWithTag("Bottle").SetActive(false);
        }
        else if(isHolding == IsHolding.Salt)
        {
            GameObject.FindGameObjectWithTag("Salt").SetActive(false); ;
            GameObject.FindGameObjectWithTag("Bottle").SetActive(false);
        }
        else if (isHolding == IsHolding.Bottle)
        {
            GameObject.FindGameObjectWithTag("Salt").SetActive(false); ;
            GameObject.FindGameObjectWithTag("Bottle").SetActive(false);
        } 
    }
}
