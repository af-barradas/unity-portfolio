using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Globalization;

public class DateInput : MonoBehaviour
{
    [Header("New Expense")]
    [SerializeField] private NewExpense form;

    [Header("Date")]
    [SerializeField] int year;
    [SerializeField] int month;
    [SerializeField] int day;

    [Header("Year")]
    [SerializeField] private TextMeshProUGUI yearName;

    [Header("Month")]
    [SerializeField] private TextMeshProUGUI monthName;

    [Header("Day")]
    [SerializeField] private GameObject content; // Game object holding all the days
    [SerializeField] private GameObject selectedDay;
    [SerializeField] private GameObject dayPrefab; // Game object prefab to instantiate each day

    // Start is called before the first frame update
    private void Start()
    {
        // Get New Expense from Form
        form = GameObject.Find("Form").GetComponent<NewExpense>();

        // Get todays date
        System.DateTime today = System.DateTime.Today;

        // Fill current year
        year = today.Year;
        yearName.text = today.Year.ToString();

        // Fill current month
        month = today.Month;
        monthName.text = today.ToString("MMM");

        // Fill the days content
        day = today.Day;
        int daysInMonth = System.DateTime.DaysInMonth(today.Year, today.Month);

        for (int i = 1; i <= daysInMonth; i++)
        {
            GameObject newDay = Instantiate(dayPrefab, content.transform);
            newDay.GetComponentInChildren<TextMeshProUGUI>().text = i.ToString();
            if (i == today.Day)
            {
                selectedDay = newDay;
                newDay.GetComponentInChildren<TextMeshProUGUI>().color = Color.HSVToRGB(184f / 360, 99f / 100, 84f / 100);
                var colors = newDay.GetComponentInChildren<Button>().colors;
                colors.normalColor = Color.HSVToRGB(0f / 360, 0f / 100, 78f / 100);
                newDay.GetComponentInChildren<Button>().colors = colors;
            }
        }
    }

    // Internal functions
    private void updateYear(int newYear)
    {
        year = newYear;
        form.updateDate(year, month, day);
    }

    private void updateMonth(int newMonth)
    {
        month = newMonth;
        form.updateDate(year, month, day);
    }

    private void updateDay(int newDay)
    {
        day = newDay;
        form.updateDate(year, month, day);
    }

    // Button functions
    public void MoveYearUp()
    {
        int newYear = int.Parse(yearName.text) + 1;
        if (newYear > System.DateTime.Today.Year) return;
        updateYear(newYear);
        yearName.text = newYear.ToString();
    }
    public void MoveYearDown()
    {
        int newYear = int.Parse(yearName.text) - 1;
        if (newYear < 1970) return;
        updateYear(newYear);
        yearName.text = newYear.ToString();
    }

    public void MoveMonthUp()
    {
        int newMonth = System.DateTime.ParseExact(monthName.text, "MMM", CultureInfo.CurrentCulture).Month + 1;
        if (newMonth > 12) return;
        updateMonth(newMonth);
        monthName.text = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(newMonth);
    }
    public void MoveMonthDown()
    {
        int newMonth = System.DateTime.ParseExact(monthName.text, "MMM", CultureInfo.CurrentCulture).Month - 1;
        if (newMonth < 1) return;
        updateMonth(newMonth);
        monthName.text = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(newMonth);
    }

    // Callable functions
    public void MoveDay(GameObject newSelectedDay)
    {
        int newDay = int.Parse(newSelectedDay.GetComponentInChildren<TextMeshProUGUI>().text);
        updateDay(newDay);

        var oldColors = selectedDay.GetComponentInChildren<Button>().colors;
        oldColors.normalColor = Color.HSVToRGB(0f / 360, 0f / 100, 100f / 100);
        selectedDay.GetComponentInChildren<Button>().colors = oldColors;

        selectedDay = newSelectedDay;

        var newColors = selectedDay.GetComponentInChildren<Button>().colors;
        newColors.normalColor = Color.HSVToRGB(0f / 360, 0f / 100, 78f / 100);
        selectedDay.GetComponentInChildren<Button>().colors = newColors;
    }
}
