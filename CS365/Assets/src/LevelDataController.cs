﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDataController : MonoBehaviour
{
    // Integer to know which level this is
    public int levelNumber;

    // Floats to know the time to get every star
    public float starTime1;

    public float starTime2;

    public float starTime3;

    // The timer to know the time
    public Timer playerTime;

    // The collectible to know the number of coins colected by the player
    public GetCollectables collectibleNumber;

    // This gameobject
    public GameObject menu;

    // High score
    public float highScoreTime;

    // Coin high score
    public int highScoreCoins;

    // Run time
    public float runTime;

    // Start is called before the first frame update
    void Start()
    {
        highScoreTime = 3600.0f;
        highScoreCoins = 0;
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.collider.name == "Player")
        {
            // Create the menu
            menu.SetActive(true);

            // Store run time
            runTime = Time.time - playerTime.StartTime;

            // Save score
            SaveData();

            // Set the high scores
            LevelData temp = LoadDataForLevelData();
            if (temp == null)
                temp = new LevelData(this);

            highScoreTime = temp.highScores[levelNumber];
            highScoreCoins = temp.topCollectibleNumber[levelNumber];

            // Stop time
            Time.timeScale = 0.0f;
        }
    }

    // Saves the level's data
    public void SaveData()
    {
        LevelDataLoader.SaveLevelStats(this);
    }

    // LevelData helper function
    public LevelData LoadDataForLevelData()
    {
        return LevelDataLoader.LoadLevelData();
    }
}
