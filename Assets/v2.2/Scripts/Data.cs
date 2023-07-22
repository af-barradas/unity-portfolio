using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data
{
    [System.Serializable]
    public struct expenseStruct
    {
        public int year;
        public List<Expense> expenses;
    }

    [System.Serializable]
    public struct monthStruct
    {
        public int year;
        public int month;
        public float essentialTotal;
        public float nonEssentialTotal;
        public float vacationTotal;
        public float investmentTotal;
    }

    public List<expenseStruct> expenseInfo;
    public List<monthStruct> monthInfo;

    public float monthlyBudget;

    public Data()
    {
        // Initialize lists
        this.expenseInfo = new List<expenseStruct>();
        this.monthInfo = new List<monthStruct>(12);
        this.monthlyBudget = 0;
    }

    public Data(Data data)
    {
        // Initialize lists
        this.expenseInfo = data.expenseInfo;
        this.monthInfo = data.monthInfo;
        this.monthlyBudget = data.monthlyBudget;
    }

    public void addExpense(int index, Expense expense)
    {
        if (index == -1)
        {
            expenseStruct item;
            item.year = System.DateTime.Parse(expense.GetDate()).Year;
            item.expenses = new List<Expense>();
            item.expenses.Add(expense);
            this.expenseInfo.Add(item);
        }
        else
        {
            this.expenseInfo[index].expenses.Add(expense);
        }
    }

    public void addMonth(int year, int month, float value)
    {
        monthStruct item;
        item.month = month;
        item.year = year;
        item.essentialTotal = 0;
        item.nonEssentialTotal = 0;
        item.vacationTotal = 0;
        item.investmentTotal = 0;

        monthInfo.Add(item);
    }

    public void addMonth(int year, int month, float value, string type)
    {
        monthStruct item;
        item.month = month;
        item.year = year;
        item.essentialTotal = 0;
        item.nonEssentialTotal = 0;
        item.vacationTotal = 0;
        item.investmentTotal = 0;

        if (type == Constants.essentialName) item.essentialTotal = value;
        if (type == Constants.nonEssentialName) item.nonEssentialTotal = value;
        if (type == Constants.vacationName) item.vacationTotal = value;
        if (type == Constants.investmentName) item.investmentTotal = value;

        if (this.monthInfo.Count > 0)
        {
            monthInfo.RemoveAt(0);
        }

        monthInfo.Add(item);
    }

    public void addValue(int index, float value, string type)
    {
        monthStruct month = this.monthInfo[index];

        if (type == Constants.essentialName) month.essentialTotal += value;
        if (type == Constants.nonEssentialName) month.nonEssentialTotal += value;
        if (type == Constants.vacationName) month.vacationTotal += value;
        if (type == Constants.investmentName) month.investmentTotal += value;

        this.monthInfo[index] = month;
    }

    public float getTotal(int index)
    {
        return this.monthInfo[index].essentialTotal + this.monthInfo[index].nonEssentialTotal + this.monthInfo[index].vacationTotal + this.monthInfo[index].investmentTotal;
    }

    public float getAverage()
    {
        float total = 0;
        int cnt = 0;
        for (int i = 0; i < 11; i++)
        {
            float monthTotal = this.monthInfo[i].essentialTotal + this.monthInfo[i].nonEssentialTotal + this.monthInfo[i].vacationTotal + this.monthInfo[i].investmentTotal;
            total += monthTotal;

            if (monthTotal != 0)
            {
                cnt++;
            }
        }

        if (cnt == 0)
        {
            cnt++;
        }

        return total / cnt;
    }
}
