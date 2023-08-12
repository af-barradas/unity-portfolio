using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ListPageButtons : MonoBehaviour
{
    private bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        isOpen = true;
    }

    public void ShowExpenses(GameObject year)
    {
        Transform scrollRect = year.transform.Find("Scroll").gameObject.transform;
        Transform content = scrollRect.transform.Find("Content").gameObject.transform;
        Transform arrow = year.transform.Find("Icon").gameObject.transform;

        if (isOpen)
        {
            scrollRect.gameObject.SetActive(true);
            year.GetComponent<RectTransform>().sizeDelta = new Vector2(year.GetComponent<RectTransform>().sizeDelta.x, year.GetComponent<RectTransform>().sizeDelta.y + Constants.expenseHeight * content.childCount + 5 * (content.childCount - 1) + 40);
            Vector3 rotationOpen = arrow.transform.eulerAngles;
            rotationOpen.z = -90;
            arrow.transform.eulerAngles = rotationOpen;
            isOpen = false;
            return;
        }

        scrollRect.gameObject.SetActive(false);
        year.GetComponent<RectTransform>().sizeDelta = new Vector2(year.GetComponent<RectTransform>().sizeDelta.x, 100);
        Vector3 rotationClose = arrow.transform.eulerAngles;
        rotationClose.z = 0;
        arrow.transform.eulerAngles = rotationClose;
        isOpen = true;
    }

    public void updateCategories(GameObject filterCategoryObject)
    {
        //  category filter's information
        TMP_Dropdown filterType = this.GetComponent<TMP_Dropdown>();
        TMP_Dropdown filterCategory = filterCategoryObject.GetComponent<TMP_Dropdown>();

        List<string> categoryOptions = Constants.getTypeCategories(filterType.options[filterType.value].text);
        categoryOptions.Insert(0, "All Categories");

        filterCategory.GetComponent<TMP_Dropdown>().ClearOptions();
        filterCategory.GetComponent<TMP_Dropdown>().AddOptions(categoryOptions);

        RectTransform filterCategoryTemplate = filterCategory.transform.Find("Template").GetComponent<RectTransform>();
        filterCategoryTemplate.sizeDelta = new Vector2(filterCategoryTemplate.sizeDelta.x, categoryOptions.Count * 75f);

        if (categoryOptions.Count > 1) { filterCategory.interactable = true; }
        else { filterCategory.interactable = false; }
    }

    public void deleteExpense(GameObject expense)
    {
        GameObject key = expense.transform.Find("Key").gameObject;
        DataManager.deleteExpense(Int16.Parse(key.GetComponent<TextMeshProUGUI>().text));

        float expenseValue = float.Parse(expense.transform.Find("Value").gameObject.GetComponent<TextMeshProUGUI>().text.Split(" ")[1]);
        GameObject expenseContent = expense.transform.parent.gameObject;
        GameObject expenseScroll = expenseContent.transform.parent.gameObject;
        GameObject year = expenseScroll.transform.parent.gameObject;
        Destroy(expense);

        expenseScroll.GetComponent<RectTransform>().sizeDelta = new Vector2(expenseScroll.GetComponent<RectTransform>().sizeDelta.x, expenseScroll.GetComponent<RectTransform>().sizeDelta.y - Constants.expenseHeight);

        year.GetComponent<RectTransform>().sizeDelta = new Vector2(year.GetComponent<RectTransform>().sizeDelta.x, year.GetComponent<RectTransform>().sizeDelta.y - Constants.expenseHeight - 5);

        year.transform.Find("Value").gameObject.GetComponent<TextMeshProUGUI>().text = "€ " + (float.Parse(year.transform.Find("Value").gameObject.GetComponent<TextMeshProUGUI>().text.Split(" ")[1]) - expenseValue).ToString();

        GameObject yearContent = year.transform.parent.gameObject;
        GameObject yearScroll = yearContent.transform.parent.gameObject;
        GameObject yearList = yearScroll.transform.parent.gameObject;
        GameObject view = yearList.transform.parent.gameObject;
        GameObject yearlyAverage = view.transform.Find("Yearly Average").gameObject;

        float total = float.Parse(yearlyAverage.transform.Find("Value").gameObject.GetComponent<TextMeshProUGUI>().text.Split(" ")[1]) * yearContent.transform.childCount;
        total -= expenseValue;

        if (expenseContent.transform.childCount == 1)
        {
            Destroy(year);
        }

        yearlyAverage.transform.Find("Value").gameObject.GetComponent<TextMeshProUGUI>().text = "€ " + (total / yearContent.transform.childCount).ToString();
        //SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    public void updateList(GameObject expense)
    {
        GameObject key = expense.transform.Find("Key").gameObject;
        DataManager.deleteExpense(Int16.Parse(key.GetComponent<TextMeshProUGUI>().text));
        Destroy(expense);
        //SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
}
