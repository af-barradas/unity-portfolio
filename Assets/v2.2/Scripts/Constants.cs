using UnityEngine;

public static class Constants
{
    // Variables
    private static string savePath = Application.persistentDataPath + "/data.afsb";

    private static Color essentialColor = Color.HSVToRGB(0f / 360, 0f / 100, 25f / 100);
    private static Color nonEssentialColor = Color.HSVToRGB(0f / 360, 0f / 100, 25f / 100);
    private static Color vacationColor = Color.HSVToRGB(0f / 360, 0f / 100, 25f / 100);
    private static Color investmentColor = Color.HSVToRGB(0f / 360, 0f / 100, 25f / 100);

    // Request Functions
    public static string GetSavePath()
    {
        return savePath;
    }
}
