using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void deleteExpense(TextMeshProUGUI key)
    {
        DataManager.deleteExpense(Int16.Parse(key.text));
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
}
