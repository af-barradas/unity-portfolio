using System.Collections.Generic;

[System.Serializable]
public class Expense
{
    public string date;
    public float value;
    public string label;
    public string type;
    public float[] color;
    public string description;

    public Expense(string date, float value, string label, string type, float[] color, string description)
    {
        this.date = date;
        this.value = value;
        this.label = label;
        this.type = type;
        this.color = new float[3];
        this.color = color;
        this.description = description;
    }
}