using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities : MonoBehaviour
{
    private Current_Manager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = this.GetComponent<Current_Manager>();
    }

    // Validate values
    public bool IsStockInvalid(string code, string name, string quantity, string value)
    {
        decimal a;
        decimal b;
        if (code.Length > 10 || name.Length > 30 || !decimal.TryParse(quantity, out a) || !decimal.TryParse(value, out b))
        {
            return true;
        }
        if (b <= 0)
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
        string tmpQuantity = System.Math.Round(decimal.Parse(quantity), 2).ToString();
        string tmpValue = System.Math.Round(decimal.Parse(value), 2).ToString() + "€";

        return new[] { tmpCode, tmpName, tmpQuantity, tmpValue };
    }

    // Fix percentage
    public void FixPercentage(decimal current)
    {
        if (current <= 0)
        {
            manager.stocks.ForEach((stock) => { stock.SetPercentage(System.Math.Round(decimal.Zero, 2)); });
            return;
        }

        manager.stocks.ForEach((stock) => { stock.SetPercentage(System.Math.Round((stock.GetValue() / current * 100), 2)); });
    }

    public int CheckCode(string code)
    {
        int index = -1;

        for (var i = 0; i < manager.stocks.Count; i++)
        {
            if (manager.stocks[i].GetCode() == code)
            {
                index = i;
                return index;
            }
        }

        return index;
    }

    public void UpdateStock(int index, string quantity, string value)
    {
        manager.stocks[index].AddValues(decimal.Parse(quantity), decimal.Parse(value.Remove(value.Length - 1)));
    }


}
