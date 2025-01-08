using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel, Ui;
    public bool isPaused = false;

    public void Pause()
    {
        Ui.SetActive(false);
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Continue()
    {
        Ui.SetActive(true);
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}