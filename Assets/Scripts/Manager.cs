using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using System.Threading;

public class Manager : MonoBehaviour, IData_Manager
{
    [Header("Tops")]
    public GameObject current;

    [Header("Menus")]
    public GameObject newMenu;
    public GameObject editMenu;

    [Header("New Menu")]
    public GameObject newCode;
    public GameObject newName;
    public GameObject newQuantity;
    public GameObject newValue;

    [Header("Edit Menu")]
    public GameObject editCode;
    public GameObject editName;
    public GameObject editQuantity;
    public GameObject editValue;

    [Header("Stocks")]
    public GameObject stockList;
    public GameObject stockItem;

    [Header("Data")]
    public List<Stock> stocks;

    // Start is called before the first frame update
    void Start()
    {
        // Change decimal separator to "."
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

        // Initialize list
        stocks = new List<Stock>();

        /* // Create new stock item
        GameObject newStock = Instantiate(stockItem, stockList.transform);

        // Change values with user input
        newStock.GetComponent<Stock>().SetStock("QDVE", "QDVE.DE", "42", "760€");

        // Add to list
        stocks.Add(newStock.GetComponent<Stock>());

        // Move stock item inside stock list
        newStock.transform.SetParent(stockList.transform); */
    }

    // Update is called once per frame
    /* void Update()
    {

    } */

    public void LoadData(Data data)
    {
        this.stocks = data.stocks;
    }

    public void SaveData(ref Data data)
    {
        data.stocks = this.stocks;
    }
}
