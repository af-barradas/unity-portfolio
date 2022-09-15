using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data
{
    public List<Stock> stocks;

    public Data()
    {
        // Initialize list
        this.stocks = new List<Stock>();
    }
}
