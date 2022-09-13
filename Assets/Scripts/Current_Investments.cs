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
        string value = manager.newValue.GetComponent<TMP_InputField>().text;

        // Validate values
        if (utilities.IsStockInvalid(code, name, quantity, value))
        {
            Cancel();
            return;
        }

        // Update total value
        int current = int.Parse(manager.current.GetComponent<TextMeshProUGUI>().text.Remove(manager.current.GetComponent<TextMeshProUGUI>().text.Length - 1));
        current += int.Parse(value);
        manager.current.GetComponent<TextMeshProUGUI>().text = current + "€";

        // Fix values
        string[] stockValues = utilities.FixStock(code, name, quantity, value);

        // Create new stock item
        GameObject newStock = Instantiate(manager.stockItem, manager.stockList.transform);

        // Change values with user input
        newStock.GetComponent<Stock>().SetStock(stockValues[0], stockValues[1], stockValues[2], stockValues[3]);

        // Move stock item inside stock list
        newStock.transform.SetParent(manager.stockList.transform);

        // Close menus
        Cancel();
    }
    public void Edit(string code, string name, string quantity, string value)
    {
        manager.editMenu.SetActive(true);

        // Fill input with previous values
        manager.editCode.GetComponent<TMP_InputField>().text = code;
        manager.editName.GetComponent<TMP_InputField>().text = name;
        manager.editQuantity.GetComponent<TMP_InputField>().text = quantity;
        manager.editValue.GetComponent<TMP_InputField>().text = value.Remove(value.Length - 1);
    }

    public void Save()
    {
        // Get input values
        string code = manager.editCode.GetComponent<TMP_InputField>().text;
        string name = manager.editName.GetComponent<TMP_InputField>().text;
        string quantity = manager.editQuantity.GetComponent<TMP_InputField>().text;
        string value = manager.editValue.GetComponent<TMP_InputField>().text;

        // Validate values
        if (utilities.IsStockInvalid(code, name, quantity, value))
        {
            Cancel();
            return;
        }

        // Get active stock
        GameObject stock;
        stock = GameObject.FindWithTag("Active Stock");

        // Update total value
        int current = int.Parse(manager.current.GetComponent<TextMeshProUGUI>().text.Remove(manager.current.GetComponent<TextMeshProUGUI>().text.Length - 1));
        current += int.Parse(value) - int.Parse(stock.GetComponent<Stock>().GetValue().Remove(stock.GetComponent<Stock>().GetValue().Length - 1));
        manager.current.GetComponent<TextMeshProUGUI>().text = current + "€";

        // Fix values
        string[] stockValues = utilities.FixStock(code, name, quantity, value);

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
