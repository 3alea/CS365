using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayData : MonoBehaviour
{
    // Enum to determine which type of data to display
    public enum dataType{ eTime, eBestTime, eCoins, eBestCoins };

    public dataType myType;

    // The place to get the data from
    public LevelDataController data;

    // Text to modify
    public Text text;

    // Temp
    public float temp;

    // Start is called before the first frame update
    void Start()
    {
        text = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // Display different data depending on the type
        switch (myType)
        {
            case dataType.eTime:
                text.text = "Time: " + System.Math.Round(data.runTime, 1);
                break;

            case dataType.eBestTime:
                temp = data.highScoreTime;
                text.text = "Highscore: " + data.highScoreTime;
                break;

            case dataType.eCoins:
                text.text = "Coins: " + data.collectibleNumber.CollectableNumber;
                break;

            case dataType.eBestCoins:
                text.text = "Most coins: " + data.highScoreCoins;
                break;
        }
    }
}
