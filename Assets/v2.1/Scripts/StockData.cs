using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StockData
{
    public string code;
    public string name;
    public string quantity;
    public string value;

    public StockData()
    {
        code = "";
        name = "";
        quantity = "";
        value = "";
    }
}
