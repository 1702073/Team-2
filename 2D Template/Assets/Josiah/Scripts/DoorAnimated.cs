using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimated : MonoBehaviour
{
    private Animator animator;

    public Shake shake;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        shake = GetComponent<Shake>();
    }
    public void OpenDoor()
    {
        animator.SetBool("Open", true);
        GetComponent<Shake>().CamShake();
    }

    public void CloseDoor()
    {
        animator.SetBool("Open", false);
    }
}
