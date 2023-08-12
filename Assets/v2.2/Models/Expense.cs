using System.Collections.Generic;

[System.Serializable]
public class Expense
{
    private int key;
    private string date;
    private float value;
    private string type;
    private string category;
    private string description;

    public Expense()
    {
        this.key = 0;
        this.date = null;
        this.value = 0;
        this.type = null;
        this.category = null;
        this.description = null;
    }

    public Expense(int key, string date, float value, string type, string category, string description)
    {
        this.key = key;
        this.date = date;
        this.value = value;
        this.type = type;
        this.category = category;
        this.description = description;
    }

    public int GetKey()
    {
        return this.key;
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

    public float GetValue()
    {
        return this.value;
    }

    public string GetDescription()
    {
        return this.description;
    }

    public void SetKey(int key)
    {
        this.key = key;
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

    public Expense CloneExpense()
    {
        Expense newExpense = new Expense();
        newExpense.SetKey(this.GetKey());
        newExpense.SetDate(this.GetDate());
        newExpense.SetType(this.GetType());
        newExpense.SetCategory(this.GetCategory());
        newExpense.SetValue(this.GetValue());
        newExpense.SetDescription(this.GetDescription());
        return newExpense;
    }
}