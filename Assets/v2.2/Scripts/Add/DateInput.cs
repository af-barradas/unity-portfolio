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
    private int activeDays;

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
        activeDays = daysInMonth;

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
        if (day > 10) content.transform.localPosition = new Vector3(content.transform.localPosition.x + (10 - day) * Constants.dayWidth, content.transform.localPosition.y, content.transform.localPosition.z);
    }

    // Internal functions
    private void UpdateDays(System.DateTime today)
    {
        int oldMonth = activeDays;
        int newMonth = System.DateTime.DaysInMonth(today.Year, today.Month);

        for (int i = oldMonth; i > newMonth; i--)
        {
            content.transform.GetChild(i - 1).gameObject.SetActive(false);
            activeDays--;
        }

        for (int i = oldMonth; i < newMonth; i++)
        {
            content.transform.GetChild(i).gameObject.SetActive(true);
            activeDays++;
        }
    }

    private void updateYear(int newYear)
    {
        System.DateTime today = System.DateTime.Parse(year + "-" + month + "-" + day);
        year = newYear;
        int years = newYear - today.Year;
        System.DateTime newDay = today.AddYears(years);
        UpdateDays(newDay);
        form.updateDate(year, month, day);
    }

    private void updateMonth(int newMonth)
    {
        System.DateTime today = System.DateTime.Parse(year + "-" + month + "-" + day);
        month = newMonth;
        int months = newMonth - today.Month;
        System.DateTime newDay = today.AddMonths(months);
        UpdateDays(newDay);
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

        if (month > System.DateTime.Today.Month)
            for (int i = month - System.DateTime.Today.Month; i > 0; i--)
            {
                MoveMonthDown();
            }
    }
    public void MoveYearDown()
    {
        int newYear = int.Parse(yearName.text) - 1;
        if (newYear < System.DateTime.Today.Year - 2) return;
        updateYear(newYear);
        yearName.text = newYear.ToString();
    }

    public void MoveMonthUp()
    {
        int newMonth = System.DateTime.ParseExact(monthName.text, "MMM", CultureInfo.CurrentCulture).Month + 1;
        if (newMonth > 12 || (System.DateTime.Today.Year == year && newMonth > month)) return;
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
        oldColors.selectedColor = Color.HSVToRGB(0f / 360, 0f / 100, 100f / 100);
        selectedDay.GetComponentInChildren<Button>().colors = oldColors;

        selectedDay = newSelectedDay;

        var newColors = selectedDay.GetComponentInChildren<Button>().colors;
        newColors.normalColor = Color.HSVToRGB(0f / 360, 0f / 100, 78f / 100);
        newColors.selectedColor = Color.HSVToRGB(0f / 360, 0f / 100, 78f / 100);
        selectedDay.GetComponentInChildren<Button>().colors = newColors;
    }
}
