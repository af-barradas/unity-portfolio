using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class DataManager
{
    public static Data data;
    public static int selectedExpense = -1;

    public static void selectExpense(int key)
    {
        DataManager.selectedExpense = key;
    }

    public static void addExpense(Expense expense)
    {
        DataManager.updateMonthData(expense.GetDate(), expense.GetValue(), expense.GetType());
        DataManager.updateExpenseData(expense);
        SaveSystem.Save(DataManager.data);
    }

    public static void addMonthly(Expense expense)
    {
        System.DateTime today = System.DateTime.Today;
        //DataManager.updateMonthData(today.Year + "-" + today.Month + "-1", expense.GetValue(), expense.GetType());
        //DataManager.updateExpenseData(expense.CloneExpense());
        DataManager.data.addMonthlyExpense(expense.CloneExpense());
        DataManager.updateMonthly();
        SaveSystem.Save(DataManager.data);
    }

    public static void updateMonthly()
    {
        System.DateTime today = System.DateTime.Today;

        for (int i = 0; i < DataManager.data.monthlyExpenses.Count; i++)
        {
            System.DateTime lastDate = System.DateTime.Parse(DataManager.data.monthlyExpenses[i].GetDate());
            int year = lastDate.Year;
            int month = lastDate.Month;
            if (year != today.Year || month != today.Month)
            {
                for (int j = year; j <= today.Year; j++)
                {
                    for (int k = month; k <= today.Month || (k <= 12 && j < today.Year); k++)
                    {
                        DataManager.data.monthlyExpenses[i].SetDate(j + "-" + k + "-1");
                        Expense expense = new Expense();
                        expense.SetDate(DataManager.data.monthlyExpenses[i].GetDate());
                        expense.SetType(DataManager.data.monthlyExpenses[i].GetType());
                        expense.SetDescription(DataManager.data.monthlyExpenses[i].GetDescription());
                        expense.SetCategory(DataManager.data.monthlyExpenses[i].GetCategory());
                        expense.SetValue(DataManager.data.monthlyExpenses[i].GetValue());
                        DataManager.updateExpenseData(expense);
                        DataManager.updateMonthData(expense.GetDate(), expense.GetValue(), expense.GetType());
                    }

                    month = 1;
                }
            }
        }
    }

    public static void deleteExpense(int key)
    {
        Expense expense = DataManager.data.getExpenseByKey(key);
        DataManager.updateMonthData(expense.GetDate(), -expense.GetValue(), expense.GetType());
        DataManager.data.deleteExpense(key);
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
