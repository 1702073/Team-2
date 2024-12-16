using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    public string Scene = "Choice";
    public void play()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(Scene);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
