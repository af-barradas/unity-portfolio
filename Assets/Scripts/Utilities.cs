using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Validate values
    public bool isStockInvalid(string code, string name, string quantity, string value)
    {
        int number;
        if (code.Length > 10 || name.Length > 30 || !int.TryParse(quantity, out number) || !int.TryParse(value, out number))
        {
            return true;
        }
        return false;
    }

    // Fix values
    public string[] fixStock(string code, string name, string quantity, string value)
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
        string tmpValue = value + "€";

        return new[] { tmpCode, tmpName, tmpQuantity, tmpValue };
    }
}
