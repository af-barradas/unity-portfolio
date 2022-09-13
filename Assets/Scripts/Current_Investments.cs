using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Current_Investments : MonoBehaviour
{
    private Manager manager;
    private Utilities utilities;

    // Start is called before the first frame update
    void Start()
    {
        manager = this.GetComponent<Manager>();
        utilities = this.GetComponent<Utilities>();
    }

    public void Cancel()
    {
        // Get active stock
        GameObject stock;
        stock = GameObject.FindWithTag("Active Stock");

        // Check if any is active
        if (stock != null)
        {
            // Desactivate stock
            stock.tag = "Untagged";
        }

        // Clean inputs
        manager.newCode.GetComponent<TMP_InputField>().text = "";
        manager.newName.GetComponent<TMP_InputField>().text = "";
        manager.newQuantity.GetComponent<TMP_InputField>().text = "";
        manager.newValue.GetComponent<TMP_InputField>().text = "";

        manager.editCode.GetComponent<TMP_InputField>().text = "";
        manager.editName.GetComponent<TMP_InputField>().text = "";
        manager.editQuantity.GetComponent<TMP_InputField>().text = "";
        manager.editValue.GetComponent<TMP_InputField>().text = "";

        manager.newMenu.SetActive(false);
        manager.editMenu.SetActive(false);
    }

    public void New()
    {
        manager.newMenu.SetActive(true);
    }

    public void Add()
    {
        // Get input values
        string code = manager.newCode.GetComponent<TMP_InputField>().text;
        string name = manager.newName.GetComponent<TMP_InputField>().text;
        string quantity = manager.newQuantity.GetComponent<TMP_InputField>().text;
        string unitValue = manager.newValue.GetComponent<TMP_InputField>().text;

        // Validate values
        if (utilities.IsStockInvalid(code, name, quantity, unitValue))
        {
            Cancel();
            return;
        }

        // Get transaction value
        string value = System.Math.Round((decimal.Parse(unitValue) * decimal.Parse(quantity)), 2).ToString();

        // Update total value
        decimal current = decimal.Parse(manager.current.GetComponent<TextMeshProUGUI>().text.Remove(manager.current.GetComponent<TextMeshProUGUI>().text.Length - 1));
        current += System.Math.Round(decimal.Parse(value), 2);
        manager.current.GetComponent<TextMeshProUGUI>().text = current + "€";

        // Fix values
        string[] stockValues = utilities.FixStock(code, name, quantity, value);

        // Check if code already exists
        int index = utilities.CheckCode(stockValues[0]);
        if (index != -1)
        {
            // Update existing stock
            utilities.UpdateStock(index, stockValues[2], stockValues[3]);

            Cancel();
            return;
        }

        // Create new stock item
        GameObject newStock = Instantiate(manager.stockItem, manager.stockList.transform);

        // Change values with user input
        newStock.GetComponent<Stock>().SetStock(stockValues[0], stockValues[1], stockValues[2], stockValues[3]);

        // Move stock item inside stock list
        newStock.transform.SetParent(manager.stockList.transform);

        // Add to list
        manager.stocks.Add(newStock.GetComponent<Stock>());

        // Fix percentage
        utilities.FixPercentage(current);

        // Close menus
        Cancel();
    }

    public void Edit(string code, string name, decimal quantity, decimal value)
    {
        manager.editMenu.SetActive(true);

        // Fill input with previous values
        manager.editCode.GetComponent<TMP_InputField>().text = code;
        manager.editName.GetComponent<TMP_InputField>().text = name;
        manager.editQuantity.GetComponent<TMP_InputField>().text = quantity.ToString();
        manager.editValue.GetComponent<TMP_InputField>().text = System.Math.Round((value / quantity), 2).ToString();
    }

    public void Save()
    {
        // Get input values
        string code = manager.editCode.GetComponent<TMP_InputField>().text;
        string name = manager.editName.GetComponent<TMP_InputField>().text;
        string quantity = manager.editQuantity.GetComponent<TMP_InputField>().text;
        string unitValue = manager.editValue.GetComponent<TMP_InputField>().text;

        // Validate values
        if (utilities.IsStockInvalid(code, name, quantity, unitValue))
        {
            Cancel();
            return;
        }

        // Get transaction value
        string value = System.Math.Round((decimal.Parse(unitValue) * decimal.Parse(quantity)), 2).ToString();

        // Get active stock
        GameObject stock;
        stock = GameObject.FindWithTag("Active Stock");

        // Update total value
        decimal current = decimal.Parse(manager.current.GetComponent<TextMeshProUGUI>().text.Remove(manager.current.GetComponent<TextMeshProUGUI>().text.Length - 1));
        current += decimal.Parse(value) - stock.GetComponent<Stock>().GetValue();
        manager.current.GetComponent<TextMeshProUGUI>().text = current + "€";

        // Fix values
        string[] stockValues = utilities.FixStock(code, name, quantity, value);

        // Change values with user input
        stock.GetComponent<Stock>().SetStock(stockValues[0], stockValues[1], stockValues[2], stockValues[3]);

        // Fix percentage
        utilities.FixPercentage(current);

        // Close menus
        Cancel();
    }

    public void Delete()
    {
        // Close menus
        Cancel();
    }
}
