using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    
    // Update is called once per frame
    void Update()
    {
        //Input
        Input.GetAxisRaw("Hoizontal");
       
    }

    private void FixedUpdate()
    {
        //Movment



    }

}
