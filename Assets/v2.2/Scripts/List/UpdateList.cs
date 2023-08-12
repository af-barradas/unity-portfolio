using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class UpdateList : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI average;

    public void updateAverage(GameObject expense)
    {
        GameObject value = expense.transform.Find("Value").gameObject;
        Debug.Log(value.GetComponent<TextMeshProUGUI>().text.Split(" "));
        average.text = "€ " + value.GetComponent<TextMeshProUGUI>().text;
    }
}
