using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ListPageButtons : MonoBehaviour
{
    private bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        isOpen = true;
    }

    public void ShowExpenses(GameObject year)
    {
        Transform scrollRect = year.transform.Find("Scroll").gameObject.transform;
        Transform content = scrollRect.transform.Find("Content").gameObject.transform;
        Transform arrow = year.transform.Find("Icon").gameObject.transform;

        if (isOpen)
        {
            scrollRect.gameObject.SetActive(true);
            year.GetComponent<RectTransform>().sizeDelta = new Vector2(year.GetComponent<RectTransform>().sizeDelta.x, year.GetComponent<RectTransform>().sizeDelta.y + 100 * content.childCount + 40);
            Vector3 rotationOpen = arrow.transform.eulerAngles;
            rotationOpen.z = -90;
            arrow.transform.eulerAngles = rotationOpen;
            isOpen = false;
            return;
        }

        scrollRect.gameObject.SetActive(false);
        year.GetComponent<RectTransform>().sizeDelta = new Vector2(year.GetComponent<RectTransform>().sizeDelta.x, 100);
        Vector3 rotationClose = arrow.transform.eulerAngles;
        rotationClose.z = 0;
        arrow.transform.eulerAngles = rotationClose;
        isOpen = true;
    }
}