using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLogic : MonoBehaviour
{
    public GameObject menuCanvas;
    public MouseCapturer mouse;
    public GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager mng = FindObjectOfType<AudioManager>();
        mng.StopAllSounds();

        mng.Play("MusicMenu");

        mouse = Camera.GetComponent<MouseCapturer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit") && SceneManager.GetActiveScene().name == "Menu(Galaxy)")
        {
            SceneManager.LoadScene("Scenes/SampleLevel");
        }
        /*if (Input.GetKey("[+]"))
        {
            MenuController.ShowMenu(MenuController.MenuType.LEVEL_SELECTION_MENU);
            GameObject obj = GameObject.Find("Canvas");
            obj.SetActive(false);
        }
        if (Input.GetKey("tab"))
        {
            MenuController.ShowMenu(MenuController.MenuType.SETTINGS_MENU);
            GameObject obj = GameObject.Find("Canvas");
            obj.SetActive(false);
        }*/
        if (Input.GetKey("escape"))
        {
            if(SceneManager.GetActiveScene().name == "Menu(Galaxy)")
            {
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            else
            {
                MouseCaptureHandler.ReleaseCapturer(mouse);
                Cursor.lockState = CursorLockMode.None;
                MenuController.ShowMenu(MenuController.MenuType.PAUSE_MENU);
            }
        }

    }
}
