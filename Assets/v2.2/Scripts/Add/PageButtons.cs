using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PageButtons : MonoBehaviour
{
    private NewExpense newExpense;
    private AnimationInput animationInput;

    private CheckInput checkInput;

    // Start is called before the first frame update
    private void Start()
    {
        // Get New Expense from Form
        newExpense = GameObject.Find("Form").GetComponent<NewExpense>();

        // Get Animation Input from Form
        animationInput = GameObject.Find("Form").GetComponent<AnimationInput>();

        // Get Check Input from Form
        checkInput = GameObject.Find("Form").GetComponent<CheckInput>();
    }

    public void Next()
    {
        checkInput.CheckStep1();
    }

    public void Add()
    {
        checkInput.CheckStep2();
    }

    public void Back()
    {
        checkInput.Back();
    }

    public void Close()
    {
        animationInput.UpdateWarningStatus(false, "");
    }

    /* public void Edit()
    {
        checkInput.CheckStep2Edit();
    } */

    /* public void Delete()
    {
        newExpense.Delete();
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    } */
}
