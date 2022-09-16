using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using System.Threading;
using TMPro;

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
    public List<StockData> data;

    [Header("Utilities")]
    private Utilities utilities;

    // Start is called before the first frame update
    void Start()
    {
        // Change decimal separator to "."
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

        // Initialize list
        stocks = new List<Stock>();

        // Initialize data list
        data = new List<StockData>();

        utilities = this.GetComponent<Utilities>();
    }

    // Update is called once per frame
    /* void Update()
    {

    } */

    public void Add(Stock stock)
    {
        this.stocks.Add(stock);

        StockData data = new StockData();
        data.code = stock.GetCode();
        data.name = stock.GetName();
        data.quantity = stock.GetQuantity().ToString();
        data.value = stock.GetValue().ToString() + "€";

        this.data.Add(data);
    }

    public void LoadData(Data data)
    {
        this.data = data.stocks;
        this.current.GetComponent<TextMeshProUGUI>().text = data.current;

        foreach (StockData item in this.data)
        {
            // Create new stock item
            GameObject newStock = Instantiate(stockItem, stockList.transform);

            // Change values with user input
            newStock.GetComponent<Stock>().SetStock(item.code, item.name, item.quantity, item.value);

            // Add to list
            stocks.Add(newStock.GetComponent<Stock>());

            // Move stock item inside stock list
            newStock.transform.SetParent(stockList.transform);
        }

        utilities.FixPercentage(decimal.Parse(this.current.GetComponent<TextMeshProUGUI>().text.Remove(this.current.GetComponent<TextMeshProUGUI>().text.Length - 1)));
    }

    public void SaveData(ref Data data)
    {
        data.stocks = this.data;
        data.current = this.current.GetComponent<TextMeshProUGUI>().text;
    }
}
