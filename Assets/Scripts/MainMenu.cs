using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }

    public void Options()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}