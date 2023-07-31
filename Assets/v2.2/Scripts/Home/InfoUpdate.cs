using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Globalization;

public class InfoUpdate : MonoBehaviour
{
    float[] percentages = new float[] { 58.65f, 32.14f, 9.21f };

    [SerializeField] private GameObject chartPieces;
    [SerializeField] private Image chartPiecePrefab;

    [SerializeField] private TextMeshProUGUI monthName;
    [SerializeField] private TextMeshProUGUI monthValue;

    [SerializeField] private TextMeshProUGUI essentialValue;
    [SerializeField] private TextMeshProUGUI nonEssentialValue;
    [SerializeField] private TextMeshProUGUI vacationValue;
    [SerializeField] private TextMeshProUGUI investmentValue;

    [SerializeField] private TextMeshProUGUI essentialPct;
    [SerializeField] private TextMeshProUGUI nonEssentialPct;
    [SerializeField] private TextMeshProUGUI vacationPct;
    [SerializeField] private TextMeshProUGUI investmentPct;

    [SerializeField] private TextMeshProUGUI budgetComparison;
    [SerializeField] private TextMeshProUGUI monthAverage;

    [SerializeField] private TMP_InputField monthlyBudget;

    private System.DateTime today;

    public void updateHomePage()
    {
        // Update Values
        // Get todays date
        today = System.DateTime.Today;

        monthlyBudget.text = DataManager.data.monthlyBudget.ToString();

        monthName.text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DataManager.data.monthInfo[11].month);

        float totalValue = DataManager.data.getTotal(11);

        monthValue.text = "€ " + totalValue.ToString();
        essentialValue.text = "€ " + DataManager.data.monthInfo[11].essentialTotal;
        nonEssentialValue.text = "€ " + DataManager.data.monthInfo[11].nonEssentialTotal;
        vacationValue.text = "€ " + DataManager.data.monthInfo[11].vacationTotal;
        investmentValue.text = "€ " + DataManager.data.monthInfo[11].investmentTotal;

        float essentialPercentage = 0;
        float nonEssentialPercentage = 0;
        float vacationPercentage = 0;
        float investmentPercentage = 0;
        if (totalValue > 0)
        {
            essentialPercentage = roundBy2(DataManager.data.monthInfo[11].essentialTotal / totalValue * 100);
            essentialPct.text = essentialPercentage + " %";

            nonEssentialPercentage = roundBy2(DataManager.data.monthInfo[11].nonEssentialTotal / totalValue * 100);
            nonEssentialPct.text = nonEssentialPercentage + " %";

            vacationPercentage = roundBy2(DataManager.data.monthInfo[11].vacationTotal / totalValue * 100);
            vacationPct.text = vacationPercentage + " %";

            investmentPercentage = roundBy2(DataManager.data.monthInfo[11].investmentTotal / totalValue * 100);
            investmentPct.text = investmentPercentage + " %";
        }
        else
        {
            essentialPct.text = essentialPercentage + " %";
            nonEssentialPct.text = nonEssentialPercentage + " %";
            vacationPct.text = vacationPercentage + " %";
            investmentPct.text = investmentPercentage + " %";
        }

        float budgetMath = Mathf.Round((DataManager.data.monthlyBudget - totalValue) * 100f) / 100f;
        budgetComparison.text = "€ " + budgetMath.ToString();

        if (budgetMath >= 0)
        {
            budgetComparison.color = Constants.positiveColor;
        }
        else
        {
            budgetComparison.color = Constants.negativeColor;
        }

        monthAverage.text = "€ " + roundBy2(DataManager.data.getAverage()).ToString();

        // Update Chart
        float rotation = 180;
        Image essentialPiece = Instantiate(chartPiecePrefab, chartPieces.transform);
        essentialPiece.fillAmount = essentialPercentage / 100;
        essentialPiece.color = Constants.essentialColor;
        Vector3 essentialPieceRotation = essentialPiece.transform.eulerAngles;
        essentialPieceRotation.z = rotation;
        essentialPiece.transform.eulerAngles = essentialPieceRotation;

        rotation -= 360 * essentialPercentage / 100;

        Image nonEssentialPiece = Instantiate(chartPiecePrefab, chartPieces.transform);
        nonEssentialPiece.fillAmount = nonEssentialPercentage / 100;
        nonEssentialPiece.color = Constants.nonEssentialColor;
        Vector3 nonEssentialPieceRotation = nonEssentialPiece.transform.eulerAngles;
        nonEssentialPieceRotation.z = rotation;
        nonEssentialPiece.transform.eulerAngles = nonEssentialPieceRotation;

        rotation -= 360 * nonEssentialPercentage / 100;

        Image vacationPiece = Instantiate(chartPiecePrefab, chartPieces.transform);
        vacationPiece.fillAmount = vacationPercentage / 100;
        vacationPiece.color = Constants.vacationColor;
        Vector3 vacationPieceRotation = vacationPiece.transform.eulerAngles;
        vacationPieceRotation.z = rotation;
        vacationPiece.transform.eulerAngles = vacationPieceRotation;

        rotation -= 360 * vacationPercentage / 100;

        Image investmentPiece = Instantiate(chartPiecePrefab, chartPieces.transform);
        investmentPiece.fillAmount = investmentPercentage / 100;
        investmentPiece.color = Constants.investmentColor;
        Vector3 investmentPieceRotation = investmentPiece.transform.eulerAngles;
        investmentPieceRotation.z = rotation;
        investmentPiece.transform.eulerAngles = investmentPieceRotation;
    }

    private float roundBy2(float value)
    {
        return Mathf.Round(value * 100f) / 100f;
    }
}
