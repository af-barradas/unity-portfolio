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
    public List<Expense> monthlyExpenses;

    public float monthlyBudget;
    public int lastKey;
    public int monthlyLastKey;

    public Data()
    {
        // Initialize lists
        this.expenseInfo = new List<expenseStruct>();
        this.monthInfo = new List<monthStruct>(12);
        this.monthlyExpenses = new List<Expense>();
        this.monthlyBudget = 0;
        this.lastKey = 0;
        this.monthlyLastKey = 0;
    }

    public Data(Data data)
    {
        // Initialize lists
        this.expenseInfo = data.expenseInfo;
        this.monthInfo = data.monthInfo;
        this.monthlyExpenses = data.monthlyExpenses;
        this.monthlyBudget = data.monthlyBudget;
        this.lastKey = data.lastKey;
        this.monthlyLastKey = data.monthlyLastKey;
    }

    public void addExpense(int index, Expense expense)
    {
        this.lastKey++;
        expense.SetKey(this.lastKey);

        if (index == -1)
        {
            int year = System.DateTime.Parse(expense.GetDate()).Year;
            expenseStruct item;
            item.year = year;
            item.expenses = new List<Expense> { expense };

            if (this.expenseInfo.Count == 0)
            {
                this.expenseInfo.Add(item);
                return;
            }

            for (int i = 0; i < this.expenseInfo.Count; i++)
            {
                if (this.expenseInfo[i].year > year) continue;

                this.expenseInfo.Insert(i, item);
                return;
            }

            this.expenseInfo.Add(item);
        }
        else
        {
            for (int i = 0; i < this.expenseInfo[index].expenses.Count; i++)
            {
                if (System.DateTime.Parse(expense.GetDate()) >= System.DateTime.Parse(this.expenseInfo[index].expenses[i].GetDate()))
                {
                    this.expenseInfo[index].expenses.Insert(i, expense);
                    return;
                }
            }

            this.expenseInfo[index].expenses.Add(expense);
        }
    }

    public void deleteExpense(int key)
    {
        if (key == -1) return;

        for (int i = 0; i < this.expenseInfo.Count; i++)
        {
            for (int j = 0; j < this.expenseInfo[i].expenses.Count; j++)
            {
                if (this.expenseInfo[i].expenses[j].GetKey() == key)
                {
                    /* System.DateTime date = System.DateTime.Parse(this.expenseInfo[i].expenses[j].GetDate());
                    if (this.monthInfo[11].year == date.Year && this.monthInfo[11].month == date.Month)
                    {

                        string type = this.expenseInfo[i].expenses[j].GetType();
                        float value = this.expenseInfo[i].expenses[j].GetValue();

                        monthStruct currentMonth = this.monthInfo[11];

                        if (type == Constants.essential.getName()) currentMonth.essentialTotal -= value;
                        if (type == Constants.nonEssential.getName()) currentMonth.nonEssentialTotal -= value;
                        if (type == Constants.vacation.getName()) currentMonth.vacationTotal -= value;
                        if (type == Constants.investment.getName()) currentMonth.investmentTotal -= value;

                        this.monthInfo[11] = currentMonth;
                    } */

                    this.expenseInfo[i].expenses.RemoveAt(j);
                    if (this.expenseInfo[i].expenses.Count == 0) this.expenseInfo.RemoveAt(i);

                    return;
                }
            }
        }
    }

    public void deleteMonthlyExpense(int key)
    {
        if (key == -1) return;

        for (int i = 0; i < this.monthlyExpenses.Count; i++)
        {
            if (this.monthlyExpenses[i].GetKey() == key)
            {
                this.monthlyExpenses.RemoveAt(i);
                return;
            }
        }
    }

    public void addMonth(int year, int month)
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

        if (type == Constants.essential.getName()) item.essentialTotal = value;
        if (type == Constants.nonEssential.getName()) item.nonEssentialTotal = value;
        if (type == Constants.vacation.getName()) item.vacationTotal = value;
        if (type == Constants.investment.getName()) item.investmentTotal = value;

        if (this.monthInfo.Count > 0)
        {
            monthInfo.RemoveAt(0);
        }

        monthInfo.Add(item);
    }

    public void addValue(int index, float value, string type)
    {
        monthStruct month = this.monthInfo[index];

        if (type == Constants.essential.getName()) month.essentialTotal += value;
        if (type == Constants.nonEssential.getName()) month.nonEssentialTotal += value;
        if (type == Constants.vacation.getName()) month.vacationTotal += value;
        if (type == Constants.investment.getName()) month.investmentTotal += value;

        this.monthInfo[index] = month;
    }

    public void addMonthlyExpense(Expense expense)
    {
        this.monthlyLastKey++;
        expense.SetKey(this.monthlyLastKey);
        this.monthlyExpenses.Add(expense);
    }

    public float getTotalYear(int index)
    {
        float total = 0;
        for (int i = 0; i < this.expenseInfo[index].expenses.Count; i++)
        {
            total += this.expenseInfo[index].expenses[i].GetValue();
        }
        return total;
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
            float monthTotal = this.monthInfo[i].essentialTotal + this.monthInfo[i].nonEssentialTotal + this.monthInfo[i].vacationTotal/*  + this.monthInfo[i].investmentTotal */;
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

    public Expense getExpenseByKey(int key)
    {
        for (int i = 0; i < this.expenseInfo.Count; i++)
        {
            for (int j = 0; j < this.expenseInfo[i].expenses.Count; j++)
            {
                if (this.expenseInfo[i].expenses[j].GetKey() == key)
                {
                    return this.expenseInfo[i].expenses[j];
                }
            }
        }

        return null;
    }

    public List<Expense> getMonthlyExpenses()
    {
        return this.monthlyExpenses;
    }
}
