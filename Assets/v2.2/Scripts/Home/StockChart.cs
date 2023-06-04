using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Threading.Tasks;
using System.IO;

public class StockChart : MonoBehaviour
{
    float[] percentages = new float[] { 58.65f, 32.14f, 9.21f };

    public GameObject chartPieces;
    public Image chartPiecePrefab;

    // Start is called before the first frame update
    void Start()
    {
        Data data1 = new Data();
        Expense expense1 = new Expense("Hoje", 1, "Label1", "Type1", new float[] { 1f, 1f, 1f });
        Expense expense2 = new Expense("Amanhã", 2, "Label2", "Type2", new float[] { 2f, 2f, 2f });
        data1.expenses.Add(expense1);
        data1.expenses.Add(expense2);
        Debug.Log(expense1.color[1]);
        Debug.Log(expense2.color[1]);

        SaveSystem.Save(data1);

        Data data2 = new Data(SaveSystem.Load());
        Debug.Log(data2.expenses[0].color[1]);
        Debug.Log(data2.expenses[1].color[1]);

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