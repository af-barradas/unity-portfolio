using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayInput : MonoBehaviour
{
    private Transform selectType;

    public void GetSelectedButton()
    {
        GameObject.Find("Date").GetComponent<DateInput>().MoveDay(this.gameObject);
    }
}
