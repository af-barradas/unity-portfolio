using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stock : MonoBehaviour
{
    // Set stock values
    public void setStock(string code, string name, string quantity, string value)
    {
        this.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = code;
        this.transform.GetChild(1).transform.GetChild(0).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = name;
        this.transform.GetChild(1).transform.GetChild(1).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = quantity;
        this.transform.GetChild(1).transform.GetChild(2).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = value;
    }
}
