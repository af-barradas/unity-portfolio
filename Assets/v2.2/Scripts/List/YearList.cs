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
    [SerializeField] private TextMeshProUGUI average;
    [SerializeField] private TMP_Dropdown filterType;
    [SerializeField] private RectTransform filterTypeTemplate;
    [SerializeField] private TMP_Dropdown filterCategory;
    [SerializeField] private TMP_InputField filterValue;

    // Start is called before the first frame update
    private void Start()
    {
        // Load type filter's information
        List<string> typeOptions = new List<string> { "All Types", Constants.essential.getName(), Constants.nonEssential.getName(), Constants.vacation.getName(), Constants.investment.getName() };
        filterType.AddOptions(typeOptions);
        filterTypeTemplate.sizeDelta = new Vector2(filterTypeTemplate.sizeDelta.x, typeOptions.Count * 75f);

        // Disable category filter
        filterCategory.interactable = false;

        listInfo();
    }

    public void listInfo()
    {
        // Clear expenses
        clearInfo(content);

        float total = 0;
        for (int i = 0; i < DataManager.data.expenseInfo.Count; i++)
        {
            GameObject newYear = Instantiate(year, content.transform);
            newYear.transform.Find("Name").gameObject.GetComponent<TextMeshProUGUI>().text = DataManager.data.expenseInfo[i].year.ToString();
            total += DataManager.data.getTotalYear(i);
            newYear.transform.Find("Value").gameObject.GetComponent<TextMeshProUGUI>().text = "€ " + total.ToString();

            List<Expense> expenses = DataManager.getExpenses(DataManager.data.expenseInfo[i].year);

            for (int j = 0; j < expenses.Count; j++)
            {
                GameObject scrollRect = newYear.transform.Find("Scroll").gameObject;
                GameObject newExpense = Instantiate(expense, scrollRect.transform.Find("Content").gameObject.transform);

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

        if (DataManager.data.expenseInfo.Count > 0)
        {
            average.text = "€ " + (total / DataManager.data.expenseInfo.Count).ToString();
        }

        clearInfo(content);
    }

    private void clearInfo(Transform parent)
    {
        foreach (Transform child in parent)
        {
            Destroy(child.gameObject);
        }
    }
}
