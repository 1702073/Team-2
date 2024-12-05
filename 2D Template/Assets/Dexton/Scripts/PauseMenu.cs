using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject Ui;
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        Ui.SetActive(false);
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Continue()
    {
        Ui.SetActive(true);
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
