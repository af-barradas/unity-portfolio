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
    public string percentage;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindWithTag("Manager");
    }

    // Delete stock
    public void Delete()
    {
        Destroy(gameObject);
    }

    // Get code value
    public string GetCode()
    {
        return this.code;
    }

    public string GetName()
    {
        return this.name;
    }

    public decimal GetQuantity()
    {
        return decimal.Parse(this.quantity);
    }

    public decimal GetValue()
    {
        return decimal.Parse(this.value.Remove(this.value.Length - 1));
    }

    public void SetPercentage(decimal percentage)
    {
        this.percentage = percentage.ToString() + "%";
        this.transform.GetChild(1).transform.GetChild(3).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = this.percentage;
    }

    // Set stock values
    public void SetStock(string code, string name, string quantity, string value)
    {
        this.code = code;
        this.name = name;
        this.quantity = quantity;
        this.value = value;
        this.percentage = "0%";

        this.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = this.code;
        this.transform.GetChild(1).transform.GetChild(0).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = this.name;
        this.transform.GetChild(1).transform.GetChild(1).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = this.quantity;
        this.transform.GetChild(1).transform.GetChild(2).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = this.value;
    }

    // Add quantity and value
    public void AddValues(decimal quantity, decimal value)
    {
        SetStock(this.code, this.name, (decimal.Parse(this.quantity) + quantity).ToString(), (decimal.Parse(this.value.Remove(this.value.Length - 1)) + value).ToString() + "€");
    }

    // Use edit
    public void Edit()
    {
        this.tag = "Active Stock";
        manager.GetComponent<Current_Investments>().Edit(GetCode(), GetName(), GetQuantity(), GetValue());
    }
}
