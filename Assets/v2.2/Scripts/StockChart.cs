using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Threading.Tasks;

public class StockChart : MonoBehaviour
{
    // Place holder values for testing purposes
    float[] percentages = new float[] { 58.65f, 32.14f, 9.21f };
    public GameObject chartPieces;
    public Image chartPiecePrefab;

    // Start is called before the first frame update
    void Start()
    {
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
