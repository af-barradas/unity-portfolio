using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    public Data data;

    // Start is called before the first frame update
    void Start()
    {
        // Load data
        this.data = SaveSystem.Load();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Called when the application is closed
    private void OnApplicationQuit()
    {
        // Save Data
        SaveSystem.Save(this.data);
    }
}
