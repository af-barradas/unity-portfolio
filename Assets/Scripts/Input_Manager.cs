using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Input_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject newCode;
    [SerializeField]
    private GameObject newName;
    [SerializeField]
    private GameObject newQuantity;
    [SerializeField]
    private GameObject newValue;

    // Change the whole string to upper case
    public void setStringToUpper()
    {
        string tmpString = newCode.GetComponent<TMP_InputField>().text;
        newCode.GetComponent<TMP_InputField>().text = tmpString.ToUpper();
    }

    // Change the first letter of every word to upper case
    public void setFirstCharToUpper()
    {
        string[] tmpString = newCode.GetComponent<TMP_InputField>().text.Split(" ");
        newName.GetComponent<TMP_InputField>().text = "";
        for (int i = 0; i < tmpString.Length; i++)
        {
            tmpString[i] = (char.ToUpper(tmpString[i][0]) + tmpString[i].Substring(1) + " ");
        }

        // Check if it is first letter
        if (tmpString.Length == 1)
        {

        }
        newName.GetComponent<TMP_InputField>().text = newCode.GetComponent<TMP_InputField>().text.ToUpper();
    }
}
