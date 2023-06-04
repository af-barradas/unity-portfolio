using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public static class SaveSystem
{
    // Save Function -> Receives all app info from Data and serializes it into a binary file
    public static void Save(Data data)
    {
        // Binary file path
        string path = Constants.GetSavePath();

        // Stream file to create or override file
        FileStream stream = new FileStream(path, FileMode.Create);

        // Binary formatter to serialize Data to stream
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(stream, data);

        // Close stream
        stream.Close();
    }

    // Load Function -> Deserializes a binary file and returns all app info as Data
    public static Data Load()
    {
        // Binary file path
        string path = Constants.GetSavePath();

        // Check if file doesnt exist
        if (!File.Exists(path))
        {
            // Return clean Data
            Debug.Log("Save file not found in " + path);
            return new Data();
        }

        // Stream file to open file
        FileStream stream = new FileStream(path, FileMode.Open);

        // Binary formatter to deserialize Data from stream
        BinaryFormatter formatter = new BinaryFormatter();
        Data data = new Data(formatter.Deserialize(stream) as Data);

        // Close stream
        stream.Close();

        // Return saved Data
        return data;
    }
}
