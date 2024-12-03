using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TMPro.TMP_Text ScoreText;
    public static int scoreValue = 0;
    public string format = "";

    // Update is called once per frame
    void Update()
    {
        ScoreText.SetText(string.Format(format, scoreValue));
    }
}