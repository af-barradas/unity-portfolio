using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Info : MonoBehaviour
{
    [SerializeField] private GameObject warningDateObj;
    [SerializeField] private TMP_Text warningDateText;

    [SerializeField] private GameObject checkDateObj;
    [SerializeField] private TMP_Text checkDateText;

    [SerializeField] private GameObject warningTickerObj;
    [SerializeField] private TMP_Text warningTickerText;

    [SerializeField] private GameObject checkTickerObj;
    [SerializeField] private TMP_Text checkTickerText;

    // Start is called before the first frame update
    void Start()
    {
        DisableDateWarning();
        DisableDateCheck();
        DisableTickerWarning();
        DisableTickerCheck();
    }

    public void SetDateWarning(string text)
    {
        DisableDateCheck();
        warningDateText.text = text;
        warningDateObj.SetActive(true);
    }

    public void DisableDateWarning()
    {
        warningDateObj.SetActive(false);
    }

    public void SetDateCheck(string text)
    {
        DisableDateWarning();
        checkDateText.text = text;
        checkDateObj.SetActive(true);
    }

    public void DisableDateCheck()
    {
        checkDateObj.SetActive(false);
    }

    public void SetTickerWarning(string text)
    {
        DisableTickerCheck();
        warningTickerText.text = text;
        warningTickerObj.SetActive(true);
    }

    public void DisableTickerWarning()
    {
        warningTickerObj.SetActive(false);
    }

    public void SetTickerCheck(string text)
    {
        DisableTickerWarning();
        checkTickerText.text = text;
        checkTickerObj.SetActive(true);
    }

    public void DisableTickerCheck()
    {
        checkTickerObj.SetActive(false);
    }
}
