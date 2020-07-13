using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    public string level2load;

    // Back to main menu function
    public void LoadMainMenu()
    {
        LoadCertainLevel("Menu(Galaxy)");
    }

    // Back to main menu function
    public void LoadLevel()
    {
        LoadCertainLevel(level2load);
    }

    // Back to main menu function
    static public void LoadCertainLevel(string level)
    {
        // Continue time
        Time.timeScale = 1.0f;

        SceneManager.LoadScene("Scenes/" + level);
    }
}
