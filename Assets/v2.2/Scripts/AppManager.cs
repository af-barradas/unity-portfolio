using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using System.Threading;

public class AppManager : MonoBehaviour
{
    public static Data data;

    // Start is called before the first frame update
    void Start()
    {
        // Change decimal separator to "."
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

        // Load data
        AppManager.data = SaveSystem.Load();
    }

    // Update is called once per frame
    /* void Update()
    {

    } */

    // Called when the application is closed
    private void OnApplicationQuit()
    {
        // Save Data
        SaveSystem.Save(AppManager.data);
    }
}
