using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewExpense : MonoBehaviour
{
    [Header("Expense")]
    private Expense newExpense;

    [Header("Forms")]
    [SerializeField] private GameObject stepCheck;

    [SerializeField] private GameObject step1Form;
    [SerializeField] private GameObject step2Form;

    // Start is called before the first frame update
    private void Start()
    {
        newExpense = new Expense();

        step1Form.SetActive(true);
        step2Form.SetActive(false);
    }

    public void NextBtn()
    {
        // TODO Fazer avaliações ao form para verificar se está tudo bem
        step1Form.SetActive(false);
        step2Form.SetActive(true);

        GameObject line = stepCheck.transform.Find("Line").gameObject;
        line.GetComponent<Image>().color = Color.HSVToRGB(184f / 360, 99f / 100, 84f / 100);

        GameObject step1 = stepCheck.transform.Find("Step 1").gameObject;
        GameObject uncheck1 = step1.transform.Find("Uncheck").gameObject;
        uncheck1.SetActive(false);

        GameObject step2 = stepCheck.transform.Find("Step 2").gameObject;
        GameObject uncheck2 = step2.transform.Find("Uncheck").gameObject;
        uncheck2.GetComponent<RectTransform>().sizeDelta = new Vector2(28, 28);
        uncheck2.GetComponent<Image>().color = Color.HSVToRGB(0f, 0f, 1f);

        GameObject name2 = step2.transform.Find("Name").gameObject;
        name2.GetComponent<TextMeshProUGUI>().color = Color.HSVToRGB(80f / 360, 4f / 100, 60f / 100);
    }

    // Callable functions
    public void updateDate(int year, int month, int day)
    {
        newExpense.SetDate(day + "/" + month + "/" + year);
        Debug.Log(newExpense.date);
    }
}
