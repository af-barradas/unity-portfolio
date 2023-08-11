using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CheckInput : MonoBehaviour
{
    [Header("Classes")]
    private NewExpense newExpense;
    private AnimationInput animationInput;

    [Header("Inputs")]
    [SerializeField] private TMP_InputField description;
    [SerializeField] private TMP_InputField value;

    private System.DateTime today;

    // Start is called before the first frame update
    private void Start()
    {
        newExpense = this.GetComponent<NewExpense>();
        animationInput = this.GetComponent<AnimationInput>();

        // Get todays date
        today = System.DateTime.Today;
    }

    public void CheckStep1()
    {
        newExpense.updateDescription(description.text);

        // Validate date
        if (System.DateTime.Parse(newExpense.GetDate()) > today)
        {
            animationInput.UpdateWarningStatus(true, "Invalid date");
            return;
        }

        if (newExpense.GetType() == null)
        {
            animationInput.UpdateWarningStatus(true, "Invalid type");
            return;
        }

        animationInput.UpdateWarningStatus(false, "");
        animationInput.Next(newExpense.GetType());
    }

    public void CheckStep2()
    {
        // Validate value
        if (value.text == "" || value.text == null || !((Mathf.Round(float.Parse(value.text) * 100f) / 100f) > 0f))
        {
            animationInput.UpdateWarningStatus(true, "Invalid value");
            return;
        }

        if (newExpense.GetCategory() == null)
        {
            animationInput.UpdateWarningStatus(true, "Invalid category");
            return;
        }

        newExpense.updateValue((Mathf.Round(float.Parse(value.text) * 100f) / 100f));
        animationInput.UpdateWarningStatus(false, "");
        animationInput.Add();

        newExpense.Add();

        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    /* public void CheckStep2Edit()
    {
        // Validate value
        if (value.text == "" || value.text == null || !((Mathf.Round(float.Parse(value.text) * 100f) / 100f) > 0f))
        {
            animationInput.UpdateWarningStatus(true, "Invalid value");
            return;
        }

        if (newExpense.GetCategory() == null)
        {
            animationInput.UpdateWarningStatus(true, "Invalid category");
            return;
        }

        newExpense.updateValue((Mathf.Round(float.Parse(value.text) * 100f) / 100f));
        animationInput.UpdateWarningStatus(false, "");
        animationInput.Add();

        newExpense.Edit();

        SceneManager.LoadScene(0, LoadSceneMode.Single);
    } */

    public void Back()
    {
        newExpense.updateCategory(null);
        animationInput.Back();
    }
}
