using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PauseMenuLogic : MonoBehaviour
{
    
    public void Start()
    {
        
    }
    public void OnClicked(Button button)
    {
        if(button.name == "Return")
        {
            MenuController.ShowMenu(MenuController.MenuType.NONE);
            MouseCapturer mouse = new MouseCapturer(CursorLockMode.Locked);
            MouseCaptureHandler.RegisterCapturer(mouse);
        }
        if(button.name == "LevelSelect")
        {
            MenuController.ShowMenu(MenuController.MenuType.LEVEL_SELECTION_MENU);
        }
        if (button.name == "Settings")
        {
            MenuController.ShowMenu(MenuController.MenuType.SETTINGS_MENU);
        }
        if (button.name == "MainMenu")
        {
            MenuController.ShowMenu(MenuController.MenuType.NONE);
            SceneManager.LoadScene("Menu(Galaxy)");
        }
    }
}
