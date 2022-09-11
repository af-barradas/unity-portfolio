using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Current_Investments : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Cancel()
    {
        menu.SetActive(false);
    }

    public void New()
    {
        menu.SetActive(true);
    }

    public void Add()
    {

    }
}
