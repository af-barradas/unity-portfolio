using UnityEngine;

public static class Constants
{
    // Variables
    private static string savePath = Application.persistentDataPath + "/data.afsb";

    // Request Functions
    public static string GetSavePath()
    {
        return savePath;
    }
}
