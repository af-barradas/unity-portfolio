using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManager
{
    public static Data data;
    public static Expense selectedExpense;

    public static void fillSelectedExpense(int key)
    {
        DataManager.selectedExpense = DataManager.data.getExpenseByKey(key);
    }

    public static void addExpense(Expense expense)
    {
        DataManager.updateMonthData(expense.GetDate(), expense.GetValue(), expense.GetType());
        DataManager.updateExpenseData(expense);
        SaveSystem.Save(DataManager.data);
    }

    public static void loadData()
    {
        if (DataManager.data == null)
        {
            DataManager.data = SaveSystem.Load();
        }

        DataManager.updateData();
    }

    public static void forceLoad()
    {
        DataManager.data = SaveSystem.Load();
        DataManager.updateData();
    }

    private static void updateData()
    {
        if (DataManager.data.monthInfo.Count == 0)
        {
            DataManager.createNewData(12);
            return;
        }

        DateTime lastYear = DateTime.Today.AddYears(-1);

        int cnt = 0;
        while (DataManager.data.monthInfo[0].year < lastYear.Year || (DataManager.data.monthInfo[0].year == lastYear.Year && DataManager.data.monthInfo[0].month <= lastYear.Month))
        {
            DataManager.data.monthInfo.RemoveAt(0);
            cnt++;
        }

        DataManager.createNewData(cnt);
    }

    private static void createNewData(int numberOfMonths)
    {
        int starter = (numberOfMonths - 1) * -1;

        for (int i = starter; i <= 0; i++)
        {
            DateTime newDate = DateTime.Today.AddMonths(i);
            DataManager.data.addMonth(newDate.Year, newDate.Month);
        }
    }

    private static void updateMonthData(string date, float value, string type)
    {
        for (int i = DataManager.data.monthInfo.Count - 1; i >= 0; i--)
        {
            if (DataManager.data.monthInfo[i].year == DateTime.Parse(date).Year && DataManager.data.monthInfo[i].month == DateTime.Parse(date).Month)
            {
                DataManager.data.addValue(i, value, type);
            }
        }
    }

    private static void updateExpenseData(Expense expense)
    {
        int index = -1;
        for (int i = DataManager.data.expenseInfo.Count - 1; i >= 0; i--)
        {
            if (DateTime.Parse(expense.GetDate()).Year == DataManager.data.expenseInfo[i].year)
            {
                index = i;
                break;
            }
        }

        DataManager.data.addExpense(index, expense);
    }

    public static void updateMonthlyBudget(string monthlyBudget)
    {
        DataManager.data.monthlyBudget = Mathf.Round(float.Parse(monthlyBudget) * 100f) / 100f;
    }

    public static List<Expense> getExpenses(int year)
    {
        for (int i = 0; i < DataManager.data.expenseInfo.Count; i++)
        {
            if (DataManager.data.expenseInfo[i].year == year)
            {
                return DataManager.data.expenseInfo[i].expenses;
            }
        }
        return null;
    }
}
