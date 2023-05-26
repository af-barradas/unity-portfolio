using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Data_Handler
{
    private string dataDirPath = "";
    private string dataFileName = "";

    public Data_Handler(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }

    public Data Load()
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);

        Data loadedData = null;

        if (File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";

                using (FileStream fs = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(fs))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                loadedData = JsonUtility.FromJson<Data>(dataToLoad);

            }
            catch (Exception e)
            {
                Debug.LogError("Error: " + fullPath + "\n" + e);
            }
        }

        return loadedData;
    }

    public void Save(Data data)
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            string dataToStore = JsonUtility.ToJson(data, true);

            using (FileStream fs = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error: " + fullPath + "\n" + e);
        }
    }
}
