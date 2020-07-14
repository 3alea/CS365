using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public enum MenuType{ PAUSE_MENU, SETTINGS_MENU, LEVEL_SELECTION_MENU, LEVEL_WIN_MENU, TOTAL, NONE };
    static MenuType mCurrentMenu;
    static MenuType mPreviousMenu;

    public GameObject PauseMenu;
    public GameObject SettingsMenu;
    public GameObject LevelSelectionMenu;
    public GameObject LevelWinMenu;

    static GameObject[] Menus = new GameObject[(int)MenuType.TOTAL];

    // Start is called before the first frame update
    void Start()
    {
        Menus[(int)MenuType.PAUSE_MENU]                 = PauseMenu;
        Menus[(int)MenuType.SETTINGS_MENU]              = SettingsMenu;
        Menus[(int)MenuType.LEVEL_SELECTION_MENU]       = LevelSelectionMenu;
        Menus[(int)MenuType.LEVEL_WIN_MENU]             = LevelWinMenu;

        // Initialize current menu to none, since none should be visible at this point
        mCurrentMenu = mPreviousMenu = MenuType.NONE;

        for (int i = 0; i < (int)MenuType.TOTAL; ++i)
        {
            if (Menus[i]) Menus[i].SetActive(false);
        }
    }

    static public MenuType GiveCurrentMenu()
    {
        return mCurrentMenu;
    }

    public void GoToLevelSelection()
    {
        ShowMenu(MenuType.LEVEL_SELECTION_MENU);
    }

    public void GoBack()
    {
        ShowMenu(mPreviousMenu);
    }

    static public void ShowMenu(MenuType _menu)
    {
        // If there is an active menu, deactivate it
        if (mCurrentMenu < MenuType.TOTAL)
        {
            Menus[(int)mCurrentMenu].SetActive(false);

            // Resume time
            Time.timeScale = 1.0f;
        }

        // Set active the wanted menu (if it is a valid one)
        mPreviousMenu = mCurrentMenu;
        mCurrentMenu = _menu;

        if (mCurrentMenu < MenuType.TOTAL)
        {
            Menus[(int)mCurrentMenu].SetActive(true);

            // Stop time
            Time.timeScale = 0.0f;
        }
    }
}
