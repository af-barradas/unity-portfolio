using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeInput : MonoBehaviour
{
    private NewExpense newExpense;
    private AnimationInput animationInput;

    // Start is called before the first frame update
    void Start()
    {
        // Get New Expense from Form
        newExpense = GameObject.Find("Form").GetComponent<NewExpense>();
        animationInput = GameObject.Find("Form").GetComponent<AnimationInput>();
    }

    public void SelectType()
    {
        animationInput.moveSelectType(this.transform);
        newExpense.updateType(this.name);
    }
}
