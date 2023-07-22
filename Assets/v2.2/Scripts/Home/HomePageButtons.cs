using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HomePageButtons : MonoBehaviour
{
    private InfoUpdate infoUpdate;

    // Start is called before the first frame update
    void Start()
    {
        // Get New Expense from Form
        infoUpdate = GameObject.Find("Manager").GetComponent<InfoUpdate>();
    }

    public void Options(GameObject form)
    {
        form.SetActive(!form.activeSelf);
    }

    public void Save(TMP_InputField monthlyBudget)
    {
        DataManager.updateMonthlyBudget(monthlyBudget.text);
        infoUpdate.updateHomePage();
    }

    public void Delete()
    {
        SaveSystem.Delete();
        DataManager.forceLoad();
        infoUpdate.updateHomePage();
    }
}
