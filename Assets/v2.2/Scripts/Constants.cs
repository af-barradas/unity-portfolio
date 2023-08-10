using UnityEngine;
using System.Collections.Generic;

public static class Constants
{
    // Variables
    private static string savePath = Application.persistentDataPath + "/data.afsb";

    public static Type essential = new("Essential", new List<string> { "Groceries", "Rent", "Bills", "Gym", "Health", "House", "Transports", "Other" });
    public static Type nonEssential = new("Non Essential", new List<string> { "Restaurant", "Leisure", "Clothing", "Hardware", "House", "Gift", "Other" });
    public static Type vacation = new("Vacation", new List<string> { "Flight", "Stay", "Groceries", "Restaurant", "Sightseeing", "Gift", "Other" });
    public static Type investment = new("Investment", new List<string> { "Real Estate", "Stocks", "PPR", "Bank/Gov", "Business", "Other" });

    public static Color essentialColor = Color.HSVToRGB(34f / 360, 81f / 100, 100f / 100);
    public static Color nonEssentialColor = Color.HSVToRGB(81f / 360, 89f / 100, 86f / 100);
    public static Color vacationColor = Color.HSVToRGB(260f / 360, 48f / 100, 93f / 100);
    public static Color investmentColor = Color.HSVToRGB(185f / 360, 54f / 100, 66f / 100);

    public static Color positiveColor = Color.HSVToRGB(119f / 360, 64f / 100, 100f / 100);
    public static Color negativeColor = Color.HSVToRGB(354f / 360, 64f / 100, 100f / 100);

    public static int expenseHeight = 100;

    // Request Functions
    public static string GetSavePath()
    {
        return savePath;
    }

    public static Color getTypeColor(string type)
    {
        if (type == essential.getName())
        {
            return essentialColor;
        }
        else if (type == nonEssential.getName())
        {
            return nonEssentialColor;
        }
        else if (type == vacation.getName())
        {
            return vacationColor;
        }
        else
        {
            return investmentColor;
        }
    }

    public static List<string> getTypeCategories(string type)
    {
        if (type == essential.getName())
        {
            return essential.getCategories();
        }
        else if (type == nonEssential.getName())
        {
            return nonEssential.getCategories();
        }
        else if (type == vacation.getName())
        {
            return vacation.getCategories();
        }
        else if (type == investment.getName())
        {
            return investment.getCategories();
        }
        else
        {
            return new List<string>();
        }
    }
}