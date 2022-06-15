using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string playerName;
    public string playerNameFromData;
    public int playerScoreFromData;

    // Start is called before the first frame update
    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetName(string name)
    {
        playerName = name;
    }

    class PlayerData
    {
        public string name;
        public int score;
    }

    public void SaveData()
    {
        PlayerData data = new PlayerData();
        data.name = playerNameFromData;
        data.score = playerScoreFromData;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/save.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/save.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            playerNameFromData = data.name;
            playerScoreFromData = data.score;
        }
    }

    public string GetSaveDataName()
    {
        return playerNameFromData;
    }

    public int GetSaveDataScore()
    {
        return playerScoreFromData;
    }
}
