using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;

[System.Serializable]
public static class SaveSystem
{
    // Receives all app info from Data and serializes it into a binary file
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

    // Deserializes a binary file and returns all app info as Data
    public static Data Load()
    {
        // Binary file path
        string path = Constants.GetSavePath();

        // Check if file doesnt exist
        if (!File.Exists(path))
        {
            // Return clean Data
            Debug.Log("File not found in " + path);
            return new Data();
        }

        // Check if file is empty
        if (new FileInfo(path).Length == 0)
        {
            // Return clean Data
            Debug.Log("File in " + path + " is empty");
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

    // Deletes an existing data file
    public static void Delete()
    {
        // Binary file path
        string path = Constants.GetSavePath();

        // Check if file doesnt exist
        if (!File.Exists(path))
        {
            Debug.Log("File not found in " + path);
            return;
        }

        // Delete file
        File.Delete(path);
    }
}
