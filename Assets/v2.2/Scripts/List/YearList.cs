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

        float totalAverage = 0;
        int cntAverage = 0;
        for (int i = 0; i < DataManager.data.expenseInfo.Count; i++)
        {
            float yearTotal = 0;

            GameObject newYear = Instantiate(year, content.transform);

            List<Expense> expenses = DataManager.getExpenses(DataManager.data.expenseInfo[i].year);

            string filterTypeText = filterType.options[filterType.value].text;
            string filterCategoryText = filterCategory.options[filterCategory.value].text;
            float filterValueNumber = 0;
            try
            {
                filterValueNumber = float.Parse(filterValue.text);
            }
            catch { }

            int cnt = 0;
            for (int j = 0; j < expenses.Count; j++)
            {
                if (expenses[j].GetValue() <= filterValueNumber) continue;
                if (expenses[j].GetType() != filterTypeText && filterTypeText != null && filterTypeText != "" && filterTypeText != "All Types") continue;
                if (expenses[j].GetCategory() != filterCategoryText && filterCategoryText != null && filterCategoryText != "" && filterCategoryText != "All Categories") continue;

                if (System.DateTime.Today.Year != DataManager.data.expenseInfo[i].year) { totalAverage += expenses[j].GetValue(); cntAverage++; }
                yearTotal += expenses[j].GetValue();
                cnt++;

                GameObject scrollRect = newYear.transform.Find("Scroll").gameObject;
                GameObject newExpense = Instantiate(expense, scrollRect.transform.Find("Content").gameObject.transform);

                GameObject color = newExpense.transform.Find("Color").gameObject;
                color.GetComponent<Image>().color = Constants.getTypeColor(expenses[j].GetType());

                GameObject category = newExpense.transform.Find("Category").gameObject;
                category.GetComponent<TextMeshProUGUI>().text = expenses[j].GetCategory();

                GameObject value = newExpense.transform.Find("Value").gameObject;
                value.GetComponent<TextMeshProUGUI>().text = "€ " + expenses[j].GetValue().ToString();

                GameObject dateDescription = newExpense.transform.Find("Date and Description").gameObject;
                dateDescription.GetComponent<TextMeshProUGUI>().text = expenses[j].GetDate() + " - " + (expenses[j].GetDescription() != "" && expenses[j].GetDescription() != null ? expenses[j].GetDescription() : "No description...");

                GameObject key = newExpense.transform.Find("Key").gameObject;
                key.GetComponent<TextMeshProUGUI>().text = expenses[j].GetKey().ToString();

                /* GameObject description = newExpense.transform.Find("Description").gameObject;
                description.GetComponent<TextMeshProUGUI>().text = expenses[j].GetDescription(); */
            }

            if (cnt == 0) { Destroy(newYear); continue; }

            newYear.transform.Find("Name").gameObject.GetComponent<TextMeshProUGUI>().text = DataManager.data.expenseInfo[i].year.ToString();
            newYear.transform.Find("Value").gameObject.GetComponent<TextMeshProUGUI>().text = "€ " + yearTotal.ToString();
            newYear.transform.Find("Scroll").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(newYear.transform.Find("Scroll").gameObject.GetComponent<RectTransform>().sizeDelta.x, Constants.expenseHeight * newYear.transform.Find("Scroll").gameObject.transform.Find("Content").transform.childCount + 5 * (newYear.transform.Find("Scroll").gameObject.transform.Find("Content").transform.childCount - 1));
        }

        if (cntAverage > 0)
        {
            average.text = "€ " + roundBy2(totalAverage / cntAverage).ToString();
        }
        else
        {
            average.text = "€ 0";
        }

        //clearInfo(content);
    }

    private void clearInfo(Transform parent)
    {
        foreach (Transform child in parent)
        {
            Destroy(child.gameObject);
        }
    }

    private float roundBy2(float value)
    {
        return Mathf.Round(value * 100f) / 100f;
    }
}
