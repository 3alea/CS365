using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager mng = FindObjectOfType<AudioManager>();

        mng.StopAllSounds();

        mng.Play("MusicMenu");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            SceneManager.LoadScene("Scenes/SampleLevel");
        }
    }
}
