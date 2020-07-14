using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarSpawner : MonoBehaviour
{
    // The star
    public GameObject prefab;
    
    // The stars
    public Toggle[] stars = new Toggle[3];

    // Checks the necessary times to activate the stars
    public LevelDataController dataController;

    // Distance between stars
    public float distance;

    // Final time store
    float finalTime;

    float temp;

    // Update is called once per frame
    void Update()
    {
        // Store final time
        finalTime = dataController.runTime;

        temp = dataController.starTime1;

        // Check if the player was fast enough!
        // Star 1
        if (finalTime < dataController.starTime1)
            stars[2].isOn = true;
        else
            stars[2].isOn = false;

        // Star 2
        if (finalTime < dataController.starTime2)
            stars[1].isOn = true;
        else
            stars[1].isOn = false;

        // Star 3
        if (finalTime < dataController.starTime3)
            stars[0].isOn = true;
        else
            stars[0].isOn = false;
    }
}
