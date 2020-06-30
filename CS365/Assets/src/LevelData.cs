/*************************
 * Author: Pablo Riesco
 **************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Holds data of the level the player is playing
[System.Serializable]
public class LevelData
{
    // The timer to know the time
    public float[] highScores;

    // The collectible to know the number of coins colected by the player
    public int[] topCollectibleNumber;

    // Level data constructor getting data from level
    public LevelData(LevelDataController _levelDataController)
    {
        // Load from file the rest of the level's data
        LevelData tempData = _levelDataController.LoadDataForLevelData();

        // If loading worked correctly...
        if(tempData != null)
        {
            //Debug.Log(highScores[0]);
            highScores = tempData.highScores;
            topCollectibleNumber = tempData.topCollectibleNumber;
        }
        // If loading did not go correctly, create new high score spaces
        else
        {
            highScores = new float[5];
            topCollectibleNumber = new int[5];

            // Make the new high scores very bad
            for(int counter = 0; counter < 5; counter++)
                highScores[counter] = 3600.0f;
        }

        // Check if there is a new high score, and if there is, store it
        float attendantTime = Time.time - _levelDataController.playerTime.StartTime;

        if (attendantTime < highScores[_levelDataController.levelNumber])
            highScores[_levelDataController.levelNumber] = attendantTime;

        // Check if there is a new coin high score, and if there is, store it
        int attendantCoins = _levelDataController.collectibleNumber.CollectableNumber;

        if (attendantCoins > topCollectibleNumber[_levelDataController.levelNumber])
            topCollectibleNumber[_levelDataController.levelNumber] = attendantCoins;
    }
}
