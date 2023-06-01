using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Threading.Tasks;
using System;

public class Add : MonoBehaviour
{
    [Header("Variables")]
    private string apiUrl;
    private string apiKey;

    // Start is called before the first frame update
    void Start()
    {
        apiUrl = "https://www.alphavantage.co/query?function=";
        apiKey = "&apikey=AVGOTKYQXAKS6JY4";
    }

    async public Task<string> apiRequest(string url)
    {
        UnityWebRequest www = UnityWebRequest.Get(apiUrl + url + apiKey);
        www.SetRequestHeader("Content-Type", "application/json");

        UnityWebRequestAsyncOperation operation = www.SendWebRequest();

        while (!operation.isDone)
        {
            await Task.Yield();
        }

        if (www.result == UnityWebRequest.Result.Success)
        {
            /* Debug.Log($"Success: {JObject.Parse(www.downloadHandler.text)}");
            Debug.Log(JObject.Parse(www.downloadHandler.text).First); */
            return www.downloadHandler.text;
            //tickers = JObject.Parse(www.downloadHandler.text).Next;
        }

        else
        {
            Debug.Log($"Error: {www.error}");
            return "{error: did not expected it}";
        }
    }
}
