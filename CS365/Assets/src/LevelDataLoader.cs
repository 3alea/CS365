using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class LevelDataLoader
{
    // Saves data of levels ONLY
    public static void SaveLevelStats(LevelDataController levelController)
    {
        // Copy data
        LevelData data = new LevelData(levelController);

        // Create binary formatter
        BinaryFormatter formatter = new BinaryFormatter();

        // Create path and get stream
        string path = Application.persistentDataPath + "/ghandis.balls";
        FileStream stream = new FileStream(path, FileMode.Create);

        // Serialize data
        formatter.Serialize(stream, data);
        stream.Close();
    }

    // Loads data of levels ONLY
    public static LevelData LoadLevelData()
    {
        // Get data path
        string path = Application.persistentDataPath + "/ghandis.balls";

        // If it can be opened
        if(File.Exists(path))
        {
            // Get Binary formatter and stream
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            // Deserialize data and close file
            LevelData data = formatter.Deserialize(stream) as LevelData;

            stream.Close();

            return data;
        }
        // Error has ocurred opening file
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
