using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player_Movement : MonoBehaviour
{
    public float walkSpeed = 3f, runSpeed = 5f;
    [SerializeField] private float moveSpeed = 3f;
    public float stamina, maxStamina, runCost, chargeRate;
    public KeyCode run = KeyCode.LeftShift;

    public Rigidbody2D rb2d;
    public Animator animator;
    public Image StaminaBar;

    private Coroutine recharge;

    Vector2 movement;
    
    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale > 0)
        {
            //Input
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            movement.Normalize();

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
    }

    void FixedUpdate()
    {        
        rb2d.MovePosition(rb2d.position + movement * moveSpeed * Time.fixedDeltaTime);
        if (Input.GetKey(run) && stamina > 0)
        {
            stamina -= runCost * Time.deltaTime;
            if (stamina < 0f) stamina = 0f;
            StaminaBar.fillAmount = stamina / maxStamina;

            moveSpeed = runSpeed;
            if (recharge != null) StopCoroutine(recharge);
            recharge = StartCoroutine((string)RechargeStamina());
        }
        else
        {
            moveSpeed = walkSpeed;
        }
    }

    private IEnumerable RechargeStamina()
    {
        yield return new WaitForSeconds(1f);

        while(stamina < maxStamina)
        {
            stamina += chargeRate / 10f;
            if (stamina > maxStamina) stamina = maxStamina;
            StaminaBar.fillAmount = stamina / maxStamina;
            yield return new WaitForSeconds(1f);
        }

    }
}