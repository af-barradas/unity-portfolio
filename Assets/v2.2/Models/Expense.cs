using System.Collections.Generic;

[System.Serializable]
public class Expense
{
    private string date;
    private float value;
    private string type;
    private string category;
    private string description;

    public Expense()
    {
        this.date = null;
        this.value = 0;
        this.type = null;
        this.category = null;
        this.description = null;
    }

    public Expense(string date, float value, string type, string category, string description)
    {
        this.date = date;
        this.value = value;
        this.type = type;
        this.category = category;
        this.description = description;
    }

    public string GetDate()
    {
        return this.date;
    }

    public string GetType()
    {
        return this.type;
    }

    public string GetCategory()
    {
        return this.category;
    }

    public void SetDate(string date)
    {
        this.date = date;
    }

    public void SetType(string type)
    {
        this.type = type;
    }

    public void SetDescription(string description)
    {
        this.description = description;
    }

    public void SetCategory(string category)
    {
        this.category = category;
    }

    public void SetValue(float value)
    {
        this.value = value;
    }
}