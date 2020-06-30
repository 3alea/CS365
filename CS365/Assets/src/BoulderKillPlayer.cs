using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BoulderKillPlayer : MonoBehaviour
{
    public GameObject player;
    public Ball wc;
    public float offset = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x < transform.position.x + offset)
        {
            wc.Restart();
        }
    }
}
