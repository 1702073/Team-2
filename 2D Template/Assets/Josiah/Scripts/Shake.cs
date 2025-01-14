using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public Animator camAnim;

    public void CamShake()
    {
        int R = Random.Range(0, 3);

        camAnim.SetInteger("Variation", R);
        camAnim.SetTrigger("Shake");
    }
}
