using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class CVSLoader : MonoBehaviour
{
    private bool _debug = true;
    private const string url = "https://docs.google.com/spreadsheets/d/*/export?format=csv";

    public void DownloadTable(string sheetId, Action<string> onSheetLoadedAction)
    {
        string actualUrl = url.Replace("*", sheetId);
        StartCoroutine(DownloadRawCvsTable(actualUrl, onSheetLoadedAction));
    }

    private IEnumerator DownloadRawCvsTable(string actualUrl, Action<string> callback)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(actualUrl))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError ||
                request.result == UnityWebRequest.Result.DataProcessingError)
            {
                Debug.LogError(request.error);
            }
            else
            {
                if (_debug)
                {
                    Debug.Log("Successful download");
                    Debug.Log(request.downloadHandler.text);
                }

                callback(request.downloadHandler.text);
            }
            
        }
        yield return null;
    }
}
