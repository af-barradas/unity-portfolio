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
    private GameObject editCode;
    private GameObject editName;
    private GameObject editQuantity;
    private GameObject editValue;

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

        editCode = manager.editCode;
        editName = manager.editName;
        editQuantity = manager.editQuantity;
        editValue = manager.editValue;

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

        editCode.GetComponent<TMP_InputField>().text = "";
        editName.GetComponent<TMP_InputField>().text = "";
        editQuantity.GetComponent<TMP_InputField>().text = "";
        editValue.GetComponent<TMP_InputField>().text = "";

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
        string[] stockValues = utilities.FixStock(code, name, quantity, value);

        // Create new stock item
        GameObject newStock = Instantiate(stockItem, stockList.transform);

        // Change values with user input
        newStock.GetComponent<Stock>().SetStock(stockValues[0], stockValues[1], stockValues[2], stockValues[3]);

        // Move stock item inside stock list
        newStock.transform.SetParent(stockList.transform);

        // Close menus
        Cancel();
    }
    public void Edit(string code, string name, string quantity, string value)
    {
        editMenu.SetActive(true);

        // Fill input with previous values
        editCode.GetComponent<TMP_InputField>().text = code;
        editName.GetComponent<TMP_InputField>().text = name;
        editQuantity.GetComponent<TMP_InputField>().text = quantity;
        editValue.GetComponent<TMP_InputField>().text = value.Remove(value.Length - 1);
    }

    public void Save()
    {
        // Get input values
        string code = editCode.GetComponent<TMP_InputField>().text;
        string name = editName.GetComponent<TMP_InputField>().text;
        string quantity = editQuantity.GetComponent<TMP_InputField>().text;
        string value = editValue.GetComponent<TMP_InputField>().text;

        // Validate values
        if (utilities.IsStockInvalid(code, name, quantity, value))
        {
            Cancel();
            return;
        }

        // Fix values
        string[] stockValues = utilities.FixStock(code, name, quantity, value);

        // Get active stock
        GameObject stock;
        stock = GameObject.FindWithTag("Active Stock");

        // Change values with user input
        stock.GetComponent<Stock>().SetStock(stockValues[0], stockValues[1], stockValues[2], stockValues[3]);

        // Desactivate stock
        stock.tag = "Untagged";

        // Close menus
        Cancel();
    }

    public void Delete()
    {
        // Close menus
        Cancel();
    }
}
