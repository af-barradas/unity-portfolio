using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Data_Manager : MonoBehaviour
{
    // Only set information inside the script
    public static Data_Manager instance { get; private set; }

    [SerializeField] private string fileName;

    private Data data;
    private List<IData_Manager> dataManagerObjects;
    private Data_Handler dataHandler;

    void Start()
    {
        this.dataManagerObjects = FindAllDataManagerObjects();
        this.dataHandler = new Data_Handler(Application.persistentDataPath, fileName);
        LoadData();
    }

    public void DefaultStart()
    {
        //this.data = new Data();
    }

    public void LoadData()
    {
        this.data = dataHandler.Load();

        if (this.data == null)
        {
            DefaultStart();
        }

        foreach (IData_Manager dataManager in dataManagerObjects)
        {
            dataManager.LoadData(data);
        }
    }

    public void SaveData()
    {
        foreach (IData_Manager dataManager in dataManagerObjects)
        {
            dataManager.SaveData(ref data);
        }

        dataHandler.Save(data);
    }

    public void OnApplicationQuit()
    {
        SaveData();
    }

    private List<IData_Manager> FindAllDataManagerObjects()
    {
        IEnumerable<IData_Manager> dataManagerObjects = FindObjectsOfType<MonoBehaviour>().OfType<IData_Manager>();

        return new List<IData_Manager>(dataManagerObjects);
    }
}
