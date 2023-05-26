using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Change decimal separator to "."
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
    }

    // Transforms HSV vlues to RGB
    public Color HSTtoRGB(float h, float s, float v)
    {
        return Color.HSVToRGB(h / 360, s / 100, v / 100);
    }

    // Get the color dark gray
    public Color GetColorDarkGray()
    {
        return HSTtoRGB(240f, 3f, 13f);
    }

    // Get the color light gray
    public Color GetColorLightGray()
    {
        return HSTtoRGB(0f, 0f, 18f);
    }

    // Get the color red
    public Color GetColorRed()
    {
        return HSTtoRGB(358f, 100f, 67f);
    }

    // Get the color green
    public Color GetColorGreen()
    {
        return HSTtoRGB(135f, 99f, 58f);
    }

    // Get the color sky blue
    public Color GetColorBlue()
    {
        return HSTtoRGB(184f, 99f, 86f);
    }

    // Get the color white
    public Color GetColorWhite()
    {
        return HSTtoRGB(0f, 0f, 100f);
    }

    // Get the api key
    public string GetApiKey()
    {
        return "U9et_TLw01eYQVPrT6feXbE3FCraMS0t";
    }
}
