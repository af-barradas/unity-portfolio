using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManager
{
    public static Data data;

    public static void addExpense(Expense expense)
    {
        DataManager.data.addExpense(expense);
        DataManager.updateData(expense.GetDate(), expense.GetValue());
        SaveSystem.Save(DataManager.data);
    }

    public static void loadData()
    {
        DataManager.data = SaveSystem.Load();
    }

    private static void updateData(string date, float value)
    {
        int index = -1;
        for (int i = DataManager.data.monthInfo.Count; i >= 0; i--)
        {
            if (System.DateTime.Parse(date).Month == DataManager.data.monthInfo[i].month && System.DateTime.Parse(date).Year == DataManager.data.monthInfo[i].year)
            {
                index = i;
                break;
            }
        }

        if (index == -1)
        {
            if (DataManager.data.monthInfo[DataManager.data.monthInfo.Count - 1].year == System.DateTime.Parse(date).Year || DataManager.data.monthInfo[DataManager.data.monthInfo.Count - 1].year == System.DateTime.Parse(date).Year + 1)
            {
                data.addMonth(System.DateTime.Parse(date).Year, System.DateTime.Parse(date).Month, value);
            }
        }
        else
        {
            DataManager.data.addValue(index, value);
        }
    }
}
