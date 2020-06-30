using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // When the player collides here, instantiate in-between menu showing stats and high scores
    void OnCollisionEnter(Collision col)
    {
        //if (col.gameObject.tag == "Player")
        //{
        //    LoadMainMenu();
        //}
    }

    // Back to main menu function
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Scenes/Menu");
    }
}
