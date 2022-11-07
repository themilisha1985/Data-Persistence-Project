using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EliteList : MonoBehaviour
{
    public static EliteList Instance;
    public string playerName;
    public int score;
    public string bestPlayer;
    public int bestScore;
    // Start is called before the first frame update
    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    [System.Serializable]
    class SaveData
    {
        public string savePlayer;
        public int saveScore;
    }

    public void SaveWinnerData(string bestPlayer, int bestScore)
    {
        SaveData data = new SaveData();
        data.savePlayer = bestPlayer;
        data.saveScore = bestScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadWinnerData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            bestPlayer = data.savePlayer;
            bestScore = data.saveScore;
        }
    }
}