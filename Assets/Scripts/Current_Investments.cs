using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Current_Investments : MonoBehaviour
{
    [SerializeField]
    private GameObject newMenu;
    private GameObject editMenu;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Cancel()
    {
        newMenu.SetActive(false);
        editMenu.SetActive(false);
    }

    public void New()
    {
        newMenu.SetActive(true);
    }

    public void Add()
    {

    }
    public void Edit()
    {
        editMenu.SetActive(false);
    }
}
