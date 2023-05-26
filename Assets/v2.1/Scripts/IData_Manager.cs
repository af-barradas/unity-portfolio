using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IData_Manager
{
    void LoadData(Data data);
    void SaveData(ref Data data);
}
