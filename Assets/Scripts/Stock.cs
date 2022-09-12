using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stock : MonoBehaviour
{
    private GameObject manager;

    public string code;
    public string name;
    public string quantity;
    public string value;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindWithTag("Manager");
    }

    // Get code value
    public string GetCode()
    {
        return code;
    }

    public string GetName()
    {
        return name;
    }

    public string GetQuantity()
    {
        return quantity;
    }

    public string GetValue()
    {
        return value;
    }

    // Set stock values
    public void SetStock(string code, string name, string quantity, string value)
    {
        this.code = code;
        this.name = name;
        this.quantity = quantity;
        this.value = value;

        this.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = code;
        this.transform.GetChild(1).transform.GetChild(0).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = name;
        this.transform.GetChild(1).transform.GetChild(1).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = quantity;
        this.transform.GetChild(1).transform.GetChild(2).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = value + "€";
    }

    // Use edit
    public void Edit()
    {
        this.tag = "Active Stock";
        manager.GetComponent<Current_Investments>().Edit(GetCode(), GetName(), GetQuantity(), GetValue());
    }
}
