using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("GameHandler.Start");

        PlayerData playerData = new PlayerData();
        playerData.position = new Vector3(5, 0);
        playerData.health = 80;

        string json = JsonUtility.ToJson(playerData);
        Debug.Log(json);

        File.WriteAllText(Application.dataPath + "saveFile.json", json);

        //PlayerData loadedPlayerData = JsonUtility.FromJson<PlayerData>(json);
        //Debug.Log("position: " + loadedPlayerData.position);
        //Debug.Log("health: " + loadedPlayerData.health);
    }

    private class PlayerData
    {
        public Vector3 position;
        public int health;
    }
 
}
