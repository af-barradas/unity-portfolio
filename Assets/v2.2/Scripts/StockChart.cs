using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Threading.Tasks;
using System.IO;

public class StockChart : MonoBehaviour
{
    public ExpenseTypeList expenseTypeList1;
    public ExpenseType[] expenseTypeList2;
    float[] percentages = new float[] { 58.65f, 32.14f, 9.21f };
    
    public GameObject chartPieces;
    public Image chartPiecePrefab;

    void CreateJson() {
        ExpenseType expenseType1 = new ExpenseType();
        expenseType1.hue = 10;
        expenseType1.saturation = 10;
        expenseType1.type = "1";

        ExpenseType expenseType2 = new ExpenseType();
        expenseType2.hue = 20;
        expenseType2.saturation = 20;
        expenseType2.type = "2";

        expenseTypeList1 = new ExpenseTypeList();
        expenseTypeList1.expenseTypeList = new ExpenseType[] {expenseType1, expenseType2};

        string path = Application.dataPath + "/v2.2/Data/data.json";
        string json = JsonUtility.ToJson(expenseTypeList1);
        File.WriteAllText(path, json);
        Debug.Log(json);
    }

    void LoadJson() {
        string path = Application.dataPath + "/v2.2/Data/expense_type.json";
        string json = File.ReadAllText(path);
        expenseTypeList2 = JsonUtility.FromJson<ExpenseType[]>(json);
        Debug.Log(json);
    }

    // Start is called before the first frame update
    void Start()
    {
        //CreateJson();
        //LoadJson();
        float percentage = 0f;
        for (int i = 0; i < percentages.Length; i++)
        {
            Color color = new Color();
            color = Color.HSVToRGB(Mathf.Round(percentages[i]) / 360, 1, 1);
            Image newPiece = Instantiate(chartPiecePrefab, chartPieces.transform);
            newPiece.fillAmount = percentages[i] / 100f;
            newPiece.color = color;
            Vector3 pieceRotation = newPiece.transform.eulerAngles;
            pieceRotation.z = 360 * percentage / 100;
            newPiece.transform.eulerAngles = pieceRotation;
            percentage -= percentages[i];
        }

        //api();
    }

    // Update is called once per frame
    /* void Update()
    {
        
    } */

    async void api()
    {
        string url = "https://api.polygon.io/v3/reference/dividends?ticker=INTC&order=desc&limit=4&sort=declaration_date&apiKey=U9et_TLw01eYQVPrT6feXbE3FCraMS0t";

        UnityWebRequest www = UnityWebRequest.Get(url);

        www.SetRequestHeader("Content-Type", "application/json");

        UnityWebRequestAsyncOperation operation = www.SendWebRequest();

        while (!operation.isDone)
        {
            await Task.Yield();
        }

        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log($"Success: {www.downloadHandler.text}");
        }
        else
        {
            Debug.Log($"Error: {www.error}");
        }
    }
}

public class ExpenseTypeList
{
    public ExpenseType[] expenseTypeList;
}