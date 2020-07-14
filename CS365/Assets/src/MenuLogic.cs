using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

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
        if (Input.GetButtonDown("Submit"))
        {
            SceneManager.LoadScene("Scenes/SampleLevel");
        }
        if(Input.GetKey("escape"))
        {
            MouseCaptureHandler.ReleaseCapturer(mouse);
            Cursor.lockState = CursorLockMode.None;
            MenuController.ShowMenu(MenuController.MenuType.PAUSE_MENU);
        }

    }
}
