using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarSpawner : MonoBehaviour
{
    // The star
    public GameObject prefab;
    
    // The stars
    GameObject[] stars;

    // Checks the necessary times to activate the stars
    public LevelDataController dataController;

    // Distance between stars
    public float distance;

    // Final time store
    float finalTime;

    float temp;

    // Start is called before the first frame update
    void Start()
    {
        // Create stars
        stars = new GameObject[3];

        // Instantiate the 3 stars
        for(int counter = 0; counter < 3; counter++)
        {
            stars[counter] = Instantiate(prefab, this.transform, false);
            stars[counter].transform.localScale = new Vector3(5, 5, 0);
            stars[counter].transform.localPosition = new Vector3(counter * distance, 0.0f, 10.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Store final time
        finalTime = dataController.runTime;

        temp = dataController.starTime1;

        // Check if the player was fast enough!
        // Star 1
        if (finalTime < dataController.starTime1)
            stars[2].GetComponent<Toggle>().isOn = true;
        else
            stars[2].GetComponent<Toggle>().isOn = false;

        // Star 2
        if (finalTime < dataController.starTime2)
            stars[1].GetComponent<Toggle>().isOn = true;
        else
            stars[1].GetComponent<Toggle>().isOn = false;

        // Star 3
        if (finalTime < dataController.starTime3)
            stars[0].GetComponent<Toggle>().isOn = true;
        else
            stars[0].GetComponent<Toggle>().isOn = false;
    }
}
