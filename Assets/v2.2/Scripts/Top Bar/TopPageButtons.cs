using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Data;
using System;

public class TopPageButtons : MonoBehaviour
{
    [SerializeField] private GameObject monthlyExpensePrefab;
    [SerializeField] private GameObject form;
    [SerializeField] private Transform content;
    [SerializeField] private Sprite openIcon;
    [SerializeField] private Sprite closeIcon;
    private bool hasOpen = false;

    public void OpenList(Image icon)
    {
        if (form.activeSelf) icon.sprite = openIcon;
        else icon.sprite = closeIcon;
        form.SetActive(!form.activeSelf);

        if (!hasOpen)
        {
            hasOpen = true;

            List<Expense> monthlyExpenseList = DataManager.data.getMonthlyExpenses();

            for (int i = 0; i < monthlyExpenseList.Count; i++)
            {
                GameObject monthlyExpense = Instantiate(monthlyExpensePrefab, content);
                GameObject color = monthlyExpense.transform.Find("Color").gameObject;
                color.GetComponent<Image>().color = Constants.getTypeColor(monthlyExpenseList[i].GetType());

                GameObject category = monthlyExpense.transform.Find("Category").gameObject;
                category.GetComponent<TextMeshProUGUI>().text = monthlyExpenseList[i].GetCategory();

                GameObject value = monthlyExpense.transform.Find("Value").gameObject;
                value.GetComponent<TextMeshProUGUI>().text = "€ " + monthlyExpenseList[i].GetValue().ToString();

                GameObject key = monthlyExpense.transform.Find("Key").gameObject;
                key.GetComponent<TextMeshProUGUI>().text = monthlyExpenseList[i].GetKey().ToString();
            }
        }
    }

    public void Delete(GameObject monthlyExpense)
    {
        GameObject key = monthlyExpense.transform.Find("Key").gameObject;
        DataManager.deleteMonthlyExpense(Int16.Parse(key.GetComponent<TextMeshProUGUI>().text));
        Destroy(monthlyExpense);
    }
}
