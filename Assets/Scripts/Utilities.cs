using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities : MonoBehaviour
{
    private Manager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = this.GetComponent<Manager>();
    }

    // Validate values
    public bool IsStockInvalid(string code, string name, string quantity, string value)
    {
        int a;
        decimal b;
        if (code.Length > 10 || name.Length > 30 || !int.TryParse(quantity, out a) || !decimal.TryParse(value, out b))
        {
            return true;
        }
        return false;
    }

    // Fix values
    public string[] FixStock(string code, string name, string quantity, string value)
    {
        string tmpCode = code.ToUpper();
        string[] _name = name.Split(" ");
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
        string tmpQuantity = quantity;
        string tmpValue = System.Math.Round(decimal.Parse(value), 2).ToString() + "€";

        return new[] { tmpCode, tmpName, tmpQuantity, tmpValue };
    }

    // Fix percentage
    public void FixPercentage(decimal current)
    {
        manager.stocks.ForEach((stock) => { stock.SetPercentage(System.Math.Round((stock.GetValue() / current * 100), 2)); });
    }
}
