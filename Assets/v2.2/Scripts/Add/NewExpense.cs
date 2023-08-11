using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewExpense : MonoBehaviour
{
    [Header("Expense")]
    private Expense newExpense;

    private System.DateTime today;

    // Start is called before the first frame update
    private void Start()
    {
        newExpense = new Expense();

        // Get todays date
        today = System.DateTime.Today;

        updateDate(today.Year, today.Month, today.Day);
    }

    // Get Functions
    public string GetDate()
    {
        return newExpense.GetDate();
    }

    public string GetType()
    {
        return newExpense.GetType();
    }

    public string GetCategory()
    {
        return newExpense.GetCategory();
    }

    // Update functions
    public void updateDate(int year, int month, int day)
    {
        newExpense.SetDate(year + "-" + month + "-" + day);
    }

    public void updateType(string type)
    {
        newExpense.SetType(type);
    }

    public void updateDescription(string description)
    {
        newExpense.SetDescription(description);
    }

    public void updateCategory(string category)
    {
        newExpense.SetCategory(category);
    }

    public void updateValue(float value)
    {
        newExpense.SetValue(value);
    }

    public void Add()
    {
        DataManager.addExpense(this.newExpense);
    }

    /* public void Edit()
    {
        DataManager.editExpense(this.newExpense);
    } */

    /* public void Delete()
    {
        DataManager.deleteExpense();
    } */
}
