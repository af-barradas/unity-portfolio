using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DayInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void GetSelectedButton()
    {
        GameObject.Find("Date").GetComponent<DateInput>().MoveDay(this.gameObject);
    }
}
