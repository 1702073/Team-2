using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float walkSpeed = 3f, runSpeed = 5f;
    private float moveSpeed = 3f;
    public KeyCode run = KeyCode.LeftShift;

    public Rigidbody2D rb2d;
    public Animator animator;

    Vector2 movement;
    
    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale > 0)
        {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
         
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        }
    }

    void FixedUpdate()
    {        
        rb2d.MovePosition(rb2d.position + movement * moveSpeed * Time.fixedDeltaTime);
        if (Input.GetKey(run))
        {
            moveSpeed = runSpeed;
        }
        else
        {
            moveSpeed = walkSpeed;
        }
    }
}