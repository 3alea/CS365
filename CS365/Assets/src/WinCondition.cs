using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    public GameObject player;

    public string level2load;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Back to main menu function
    public void LoadMainMenu()
    {
        // Continue time
        Time.timeScale = 1.0f;

        SceneManager.LoadScene("Scenes/Menu(Galaxy)");
    }

    // Back to main menu function
    public void LoadLevel()
    {
        // Continue time
        Time.timeScale = 1.0f;

        SceneManager.LoadScene("Scenes/" + level2load);
    }

    // Back to main menu function
    public void LoadCertainLevel(string level)
    {
        // Continue time
        Time.timeScale = 1.0f;

        SceneManager.LoadScene("Scenes/" + level);
    }
}
