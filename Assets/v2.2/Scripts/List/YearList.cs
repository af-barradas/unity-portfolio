using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class YearList : MonoBehaviour
{
    [SerializeField] private Transform content;
    [SerializeField] private GameObject year;
    [SerializeField] private GameObject expense;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < DataManager.data.expenseInfo.Count; i++)
        {
            GameObject newYear = Instantiate(year, content.transform);
            newYear.transform.Find("Name").gameObject.GetComponent<TextMeshProUGUI>().text = DataManager.data.expenseInfo[i].year.ToString();

            List<Expense> expenses = DataManager.getExpenses(DataManager.data.expenseInfo[i].year);

            for (int j = 0; j < expenses.Count; j++)
            {
                GameObject newExpense = Instantiate(expense, newYear.transform.Find("Content").gameObject.transform);

                GameObject color = newExpense.transform.Find("Color").gameObject;
                color.GetComponent<Image>().color = Constants.getTypeColor(expenses[j].GetType());

                GameObject category = newExpense.transform.Find("Category").gameObject;
                category.GetComponent<TextMeshProUGUI>().text = expenses[j].GetCategory();

                GameObject value = newExpense.transform.Find("Value").gameObject;
                value.GetComponent<TextMeshProUGUI>().text = "€ " + expenses[j].GetValue().ToString();

                GameObject description = newExpense.transform.Find("Description").gameObject;
                description.GetComponent<TextMeshProUGUI>().text = expenses[j].GetDescription();
            }

            newYear.GetComponent<RectTransform>().sizeDelta = new Vector2(newYear.GetComponent<RectTransform>().sizeDelta.x, 100);
        }
    }
}
