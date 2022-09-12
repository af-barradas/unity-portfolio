using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Current_Investments : MonoBehaviour
{
    [Header("Manager")]
    private Manager manager;
    private Utilities utilities;

    [Header("Menus")]
    private GameObject newMenu;
    private GameObject editMenu;

    [Header("Menu's Texts")]
    private GameObject newCode;
    private GameObject newName;
    private GameObject newQuantity;
    private GameObject newValue;

    [Header("Stocks")]
    private GameObject stockList;
    private GameObject stockItem;

    // Start is called before the first frame update
    void Start()
    {
        manager = this.GetComponent<Manager>();
        utilities = this.GetComponent<Utilities>();

        newMenu = manager.newMenu;
        editMenu = manager.editMenu;

        newCode = manager.newCode;
        newName = manager.newName;
        newQuantity = manager.newQuantity;
        newValue = manager.newValue;

        stockList = manager.stockList;
        stockItem = manager.stockItem;
    }

    public void Cancel()
    {
        // Clean inputs
        newCode.GetComponent<TMP_InputField>().text = "";
        newName.GetComponent<TMP_InputField>().text = "";
        newQuantity.GetComponent<TMP_InputField>().text = "";
        newValue.GetComponent<TMP_InputField>().text = "";

        newMenu.SetActive(false);
        editMenu.SetActive(false);
    }

    public void New()
    {
        newMenu.SetActive(true);
    }

    public void Add()
    {
        // Get input values
        string code = newCode.GetComponent<TMP_InputField>().text;
        string name = newName.GetComponent<TMP_InputField>().text;
        string quantity = newQuantity.GetComponent<TMP_InputField>().text;
        string value = newValue.GetComponent<TMP_InputField>().text;

        // Validate values
        if (utilities.IsStockInvalid(code, name, quantity, value))
        {
            Cancel();
            return;
        }

        // Fix values
        string[] stock = utilities.FixStock(code, name, quantity, value);
        Debug.Log(stock[0]);

        // Create new stock item
        GameObject newStock = Instantiate(stockItem, stockList.transform);

        // Change values with user input
        newStock.GetComponent<Stock>().SetStock(stock[0], stock[1], stock[2], stock[3]);

        // Move stock item inside stock list
        newStock.transform.SetParent(stockList.transform);

        // Close menus
        Cancel();
    }
    public void Edit()
    {
        editMenu.SetActive(true);
    }

    public void Save()
    {
        editMenu.SetActive(false);
    }

    public void Delete()
    {
        editMenu.SetActive(false);
    }
}
