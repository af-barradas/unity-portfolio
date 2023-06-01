using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Input : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Add manager;
    [SerializeField] private Utilities utilities;
    [SerializeField] private Info info;

    [Header("Order Type Input")]
    [SerializeField] private Image btnBuy;
    [SerializeField] private TMP_Text textBuy;
    [SerializeField] private Image btnSell;
    [SerializeField] private TMP_Text textSell;

    [Header("Date Input")]
    [SerializeField] private TMP_InputField yearInput;
    [SerializeField] private TMP_InputField monthInput;
    [SerializeField] private TMP_InputField dayInput;

    [Header("Ticker Input")]
    [SerializeField] private TMP_InputField symbolInput;
    [SerializeField] private TMP_Dropdown marketInput;

    /* [Header("Variables")]
    private bool isBuying;
    private bool checkDate;
    private bool checkTicker;

    void Start()
    {
        yearInput.text = DateTime.Now.Year.ToString();
        monthInput.text = DateTime.Now.Month.ToString();
        dayInput.text = DateTime.Now.Day.ToString();
        info.SetDateCheck("Date: " + DateTime.Now.ToString("yyyy/M/d"));

        isBuying = true;
        checkDate = true;
        checkTicker = false;
    }

    public void Buy()
    {
        btnBuy.color = utilities.GetColorGreen();
        textBuy.color = utilities.GetColorWhite();
        btnSell.color = utilities.GetColorDarkGray();
        textSell.color = utilities.GetColorRed();
        isBuying = true;
    }

    public void Sell()
    {
        btnBuy.color = utilities.GetColorDarkGray();
        textBuy.color = utilities.GetColorGreen();
        btnSell.color = utilities.GetColorRed();
        textSell.color = utilities.GetColorWhite();
        isBuying = false;
    }

    public void CheckDate()
    {
        int year = Int16.Parse(yearInput.text);
        int month = Int16.Parse(monthInput.text);
        int day = Int16.Parse(dayInput.text);

        if (year < 1970 || year > DateTime.Now.Year) { info.SetDateWarning("Only years between 1970 and " + DateTime.Now.Year + " are allowed"); checkDate = false; return; }

        if (month < 1 || month > 12) { info.SetDateWarning("Only months between 1 and 12 are allowed"); checkDate = false; return; }

        if (day < 1 || day > 31) { info.SetDateWarning("Only days between 1 and 31 are allowed"); checkDate = false; return; }

        string date = year + "-" + month + "-" + day;
        DateTime dateInput;

        // Ver se data é válida (ex: 31 de Fev)
        if (!DateTime.TryParse(date, out dateInput)) { info.SetDateWarning("This date is not valid"); checkDate = false; return; }

        // Ver se é maior que  atual
        if (dateInput > DateTime.Now) { info.SetDateWarning("This date is not valid"); checkDate = false; return; }

        info.SetDateCheck("Date: " + yearInput.text + "/" + monthInput.text + "/" + dayInput.text);
        checkDate = true;
    } */
}
