using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Current_Investments : MonoBehaviour
{
    [Header("Menus")]
    [SerializeField]
    private GameObject newMenu;
    [SerializeField]
    private GameObject editMenu;

    [Header("Menu's Texts")]
    [SerializeField]
    private GameObject newCode;
    [SerializeField]
    private GameObject newName;
    [SerializeField]
    private GameObject newQuantity;
    [SerializeField]
    private GameObject newValue;

    [SerializeField]
    private GameObject stockItem;
    [SerializeField]
    private GameObject stockList;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Cancel()
    {
        // Clean inputs
        newCode.GetComponent<TMP_InputField>().text = "";
        newName.GetComponent<TMP_InputField>().text = "";
        newQuantity.GetComponent<TMP_InputField>().text = "";
        newValue.GetComponent<TMP_InputField>().text = "";

        newMenu.SetActive(false);
        //editMenu.SetActive(false);
    }

    public void New()
    {
        newMenu.SetActive(true);
    }

    public void Add()
    {
        // Create new stock item
        GameObject newStock = Instantiate(stockItem, stockList.transform);

        // Change values with user input
        newStock.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = newCode.GetComponent<TMP_InputField>().text;
        newStock.transform.GetChild(1).transform.GetChild(0).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = newName.GetComponent<TMP_InputField>().text;
        newStock.transform.GetChild(1).transform.GetChild(1).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = newQuantity.GetComponent<TMP_InputField>().text;
        newStock.transform.GetChild(1).transform.GetChild(2).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = newValue.GetComponent<TMP_InputField>().text;

        // Move stock item inside stock list
        newStock.transform.SetParent(stockList.transform);

        // Close menus
        newMenu.SetActive(false);
        //editMenu.SetActive(false);
    }
    public void Edit()
    {
        editMenu.SetActive(true);
    }
}
