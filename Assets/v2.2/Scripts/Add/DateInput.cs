using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Globalization;

public class DateInput : MonoBehaviour
{
    [Header("Year")]
    [SerializeField] private TextMeshProUGUI yearName;

    [Header("Month")]
    [SerializeField] private TextMeshProUGUI monthName;

    [Header("Day")]
    [SerializeField] private GameObject content; // Game object holding all the days

    [SerializeField] private GameObject day; // Game object prefab to instantiate each day

    // Start is called before the first frame update
    private void Start()
    {
        // Get todays date
        System.DateTime today = System.DateTime.Today;

        // Fill current year
        yearName.text = today.Year.ToString();

        // Fill current month
        monthName.text = today.ToString("MMM");

        // Fill the days content
        int daysInMonth = System.DateTime.DaysInMonth(today.Year, today.Month);

        for (int i = 1; i <= daysInMonth; i++)
        {
            GameObject newDay = Instantiate(day, content.transform);
            newDay.GetComponentInChildren<TextMeshProUGUI>().text = i.ToString();
            if (i == today.Day) newDay.GetComponentInChildren<TextMeshProUGUI>().color = Color.HSVToRGB(262f / 360, 74f / 100, 95f / 100);
        }
    }

    public void MoveYearUp()
    {
        int year = int.Parse(yearName.text) + 1;
        if (year > System.DateTime.Today.Year) return;
        yearName.text = year.ToString();
    }
    public void MoveYearDown()
    {
        int year = int.Parse(yearName.text) - 1;
        if (year < 1970) return;
        yearName.text = year.ToString();
    }

    public void MoveMonthUp()
    {
        int month = System.DateTime.ParseExact(monthName.text, "MMM", CultureInfo.CurrentCulture).Month + 1;
        if (month > 12) return;
        monthName.text = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(month);
    }
    public void MoveMonthDown()
    {
        int month = System.DateTime.ParseExact(monthName.text, "MMM", CultureInfo.CurrentCulture).Month - 1;
        if (month < 1) return;
        monthName.text = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(month);
    }
}
