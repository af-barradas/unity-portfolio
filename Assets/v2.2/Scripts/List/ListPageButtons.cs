using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ListPageButtons : MonoBehaviour
{
    private Transform content;
    private Transform arrow;

    private bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        content = this.transform.Find("Content").gameObject.transform;
        arrow = this.transform.Find("Icon").gameObject.transform;
        isOpen = true;
    }

    public void ShowExpenses(GameObject expense)
    {
        if (isOpen)
        {
            this.GetComponent<RectTransform>().sizeDelta = new Vector2(this.GetComponent<RectTransform>().sizeDelta.x, this.GetComponent<RectTransform>().sizeDelta.y + 100 * content.childCount + 40);
            Vector3 rotationOpen = arrow.transform.eulerAngles;
            rotationOpen.z = -90;
            arrow.transform.eulerAngles = rotationOpen;
            isOpen = false;
            return;
        }

        this.GetComponent<RectTransform>().sizeDelta = new Vector2(this.GetComponent<RectTransform>().sizeDelta.x, 100);
        Vector3 rotationClose = arrow.transform.eulerAngles;
        rotationClose.z = 0;
        arrow.transform.eulerAngles = rotationClose;
        isOpen = true;
    }
}
