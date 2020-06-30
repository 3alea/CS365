using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        //Debug.Log("TriggerEnter called\n");

        if (col.collider.CompareTag("Player"))
        {
            //Debug.Log("Collision with player detected\n");

            SceneManager.LoadScene("Scenes/Menu(Galaxy)");
        }
    }
}
