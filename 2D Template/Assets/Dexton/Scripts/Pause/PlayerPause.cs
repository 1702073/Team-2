using UnityEngine;

public class PlayerPause : MonoBehaviour
{
    public PauseMenu pauseMenu;
    public KeyCode pause = KeyCode.Escape;

    public void Update()
    {
        if (Input.GetKeyDown(pause) && pauseMenu.isPaused == false)
        {
            pauseMenu.Pause();
        }
        else if (Input.GetKeyDown(pause) && pauseMenu.isPaused == true)
        {
            pauseMenu.Continue();
        }
    }
}