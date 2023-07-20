using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data
{
    public struct expenseStruct
    {
        public int year;
        public List<Expense> expenses;
    }

    public struct monthStruct
    {
        public int year;
        public int month;
        public float total;
    }

    public List<expenseStruct> expenseInfo;
    public List<monthStruct> monthInfo;

    public Data()
    {
        // Initialize lists
        this.expenseInfo = new List<expenseStruct>();
        this.monthInfo = new List<monthStruct>(12);
    }

    public Data(Data data)
    {
        // Initialize lists
        this.expenseInfo = data.expenseInfo;
        this.monthInfo = data.monthInfo;
    }

    public void addExpense(Expense expense)
    {
        this.expenseInfo[1].expenses.Add(expense);
    }

    public void addMonth(int year, int month, float value)
    {
        monthStruct item;
        item.month = month;
        item.year = year;
        item.total = value;

        monthInfo.RemoveAt(0);
        monthInfo.Add(item);
    }

    public void addValue(int index, float value)
    {
        monthStruct month = this.monthInfo[index];
        month.total += value;
        this.monthInfo[index] = month;
    }
}
