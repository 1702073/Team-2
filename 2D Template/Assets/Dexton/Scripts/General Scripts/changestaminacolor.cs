using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changestaminacolor : MonoBehaviour
{
    public Image StamBar;
    public Sprite Green;
    public Sprite Red;

    // Start is called before the first frame update
    void ChangeSprite()
    {
        if(Player_Movement.canSprint == false)
            StamBar.sprite = Green;
        else if (Player_Movement.canSprint == true)
            StamBar.sprite = Red;
    }
}
