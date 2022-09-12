using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Current_Investments : MonoBehaviour
{
    [Header("Manager")]
    [SerializeField]
    private Manager manager;

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
        //editMenu.SetActive(false);
    }

    public void New()
    {
        newMenu.SetActive(true);
    }

    public void Add()
    {
        // Clean values
        string tmpCode = newCode.GetComponent<TMP_InputField>().text.ToUpper();
        string[] _name = newName.GetComponent<TMP_InputField>().text.Split(" ");
        string tmpName = "";
        for (int i = 0; i < _name.Length; i++)
        {
            // Check double space
            if (_name[i].Length < 1)
            {
                continue;
            }

            tmpName += (char.ToUpper(_name[i][0]) + _name[i].Substring(1) + " ");
        }
        string tmpQuantity = newQuantity.GetComponent<TMP_InputField>().text;
        string tmpValue = newValue.GetComponent<TMP_InputField>().text;

        // Validate values
        int number;
        if (tmpCode.Length > 10 || tmpName.Length > 30 || !int.TryParse(tmpQuantity, out number) || !int.TryParse(tmpValue, out number))
        {
            Cancel();
            return;
        }

        // Create new stock item
        GameObject newStock = Instantiate(stockItem, stockList.transform);

        // Change values with user input
        newStock.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = tmpCode;
        newStock.transform.GetChild(1).transform.GetChild(0).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = tmpName;
        newStock.transform.GetChild(1).transform.GetChild(1).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = tmpQuantity;
        newStock.transform.GetChild(1).transform.GetChild(2).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = tmpValue + "€";

        // Move stock item inside stock list
        newStock.transform.SetParent(stockList.transform);

        // Close menus
        Cancel();
    }
    public void Edit()
    {
        editMenu.SetActive(true);
    }
}
