using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data
{
    public List<Expense> expenses;

    public Data()
    {
        // Initialize list
        this.expenses = new List<Expense>();
    }

    public Data(Data data)
    {
        // Initialize list
        this.expenses = data.expenses;
    }

    public void addExpense(Expense expense)
    {
        this.expenses.Add(expense);
    }
}
