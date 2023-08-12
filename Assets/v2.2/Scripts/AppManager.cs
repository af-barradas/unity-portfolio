using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using System.Threading;

public class AppManager : MonoBehaviour
{
    [SerializeField] private InfoUpdate infoUpdate;

    // Start is called before the first frame update
    void Start()
    {
        // Change decimal separator to "."
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

        // Load data into Data Manager
        DataManager.loadData();

        infoUpdate.updateHomePage();

        DataManager.updateMonthly();
    }

    // Called when the application is closed
    private void OnApplicationQuit()
    {
        // Save Data
        SaveSystem.Save(DataManager.data);
    }
}
