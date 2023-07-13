using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnimationInput : MonoBehaviour
{
    [Header("Form")]
    [SerializeField] private GameObject stepCheck;

    [SerializeField] private GameObject step1Form;
    [SerializeField] private GameObject step2Form;
    [SerializeField] private GameObject warning;
    [SerializeField] private GameObject selectType;
    [SerializeField] private GameObject selectCategory;

    private GameObject activeType;
    private TextMeshProUGUI warningText;

    // Start is called before the first frame update
    void Start()
    {
        selectType.SetActive(false);
        selectCategory.SetActive(false);

        step1Form.SetActive(true);
        step2Form.SetActive(false);

        activeType = new GameObject();

        warningText = warning.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
    }

    public void Next(string type)
    {
        step1Form.SetActive(false);
        step2Form.SetActive(true);

        GameObject category = step2Form.transform.Find("Category").gameObject;
        activeType = category.transform.Find(type).gameObject;
        activeType.SetActive(true);

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
        Color newColor = Color.HSVToRGB(80f / 360, 4f / 100, 60f / 100);
        newColor.a = 1f;
        name2.GetComponent<TextMeshProUGUI>().color = newColor;
    }

    public void Back()
    {
        step1Form.SetActive(true);
        step2Form.SetActive(false);

        activeType.SetActive(false);

        GameObject line = stepCheck.transform.Find("Line").gameObject;
        line.GetComponent<Image>().color = Color.HSVToRGB(0f / 360, 0f / 100, 25f / 100);

        GameObject step1 = stepCheck.transform.Find("Step 1").gameObject;
        GameObject uncheck1 = step1.transform.Find("Uncheck").gameObject;
        uncheck1.SetActive(true);

        GameObject step2 = stepCheck.transform.Find("Step 2").gameObject;
        GameObject uncheck2 = step2.transform.Find("Uncheck").gameObject;
        uncheck2.GetComponent<RectTransform>().sizeDelta = new Vector2(33, 33);
        uncheck2.GetComponent<Image>().color = Color.HSVToRGB(0f, 0f, 25f / 100);

        GameObject name2 = step2.transform.Find("Name").gameObject;
        Color newColor = Color.HSVToRGB(90f / 360, 4f / 100, 42f / 100);
        newColor.a = 0.5f;
        name2.GetComponent<TextMeshProUGUI>().color = newColor;

        selectCategory.SetActive(false);
    }

    public void Add()
    {
        GameObject step2 = stepCheck.transform.Find("Step 2").gameObject;
        GameObject uncheck2 = step2.transform.Find("Uncheck").gameObject;
        uncheck2.SetActive(false);
    }

    public void UpdateWarningStatus(bool status, string text)
    {
        warning.SetActive(status);
        warningText.text = text;
    }

    public void moveSelectType(Transform transform)
    {
        selectType.SetActive(true);
        selectType.transform.localPosition = new Vector3(transform.localPosition.x + 45f, transform.localPosition.y + 45f, 0f);
    }

    public void moveSelectCategory(Transform transform)
    {
        selectCategory.SetActive(true);
        selectCategory.transform.localPosition = new Vector3(transform.localPosition.x + 35f, transform.localPosition.y + 110f, 0f);
    }
}