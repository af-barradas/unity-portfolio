using UnityEngine;

public static class Constants
{
    // Variables
    private static string savePath = Application.persistentDataPath + "/data.afsb";

    public static string essentialName = "Essential";
    public static string nonEssentialName = "Non Essential";
    public static string vacationName = "Vacation";
    public static string investmentName = "Investment";

    public static Color essentialColor = Color.HSVToRGB(34f / 360, 81f / 100, 100f / 100);
    public static Color nonEssentialColor = Color.HSVToRGB(81f / 360, 89f / 100, 86f / 100);
    public static Color vacationColor = Color.HSVToRGB(260f / 360, 48f / 100, 93f / 100);
    public static Color investmentColor = Color.HSVToRGB(185f / 360, 54f / 100, 66f / 100);

    // Request Functions
    public static string GetSavePath()
    {
        return savePath;
    }
}
