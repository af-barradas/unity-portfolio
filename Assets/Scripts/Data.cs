using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data
{
    public List<StockData> stocks;
    public string current;

    public Data()
    {
        // Initialize list
        this.stocks = new List<StockData>();

        this.current = "0€";
    }
}
