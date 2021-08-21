using Newtonsoft.Json;
//using Newtonsoft.Json.JsonConverter;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class TestController : MonoBehaviour
{
    [ContextMenu("Test Get")]
    public async void TestGet()
    {
        var url = "https://jsonplaceholder.Typicode.com/todos/1";

        using var www = UnityWebRequest.Get(url);

        www.SetRequestHeader("Content-Type", "application/json");

        var operation = www.SendWebRequest();

        while (!operation.isDone)
            await Task.Yield();

        var jsonResponse = www.downloadHandler.text;

        if (www.result != UnityWebRequest.Result.Success)
            Debug.LogError($"Failed : {www.error}");


        try
        {
            var result = JsonConverter.DeserializeObject<User>(jsonResponse);
            Debug.Log($"Success: {www.downloadHandler.text}");
        }
        catch (Exception ex)
        {
            Debug.LogError($" {this} Could not parse response {jsonResponse}. {ex.Message}");
        }
    }
}
