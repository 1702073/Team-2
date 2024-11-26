using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb2d;

    Vector2 movement;
    
    // Update is called once per frame
    void Update()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        //Movment
        rb2d.MovePosition(rb2d.position + movement * moveSpeed * Time.fixedDeltaTime);


    }

}
