using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomePageButtons : MonoBehaviour
{
    private InfoUpdate infoUpdate;
    [SerializeField] private GameObject form;
    [SerializeField] private Sprite openIcon;
    [SerializeField] private Sprite closeIcon;

    // Start is called before the first frame update
    void Start()
    {
        // Get New Expense from Form
        infoUpdate = GameObject.Find("Manager").GetComponent<InfoUpdate>();
    }

    public void Options(Image icon)
    {
        if (form.activeSelf) icon.sprite = openIcon;
        else icon.sprite = closeIcon;
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
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
