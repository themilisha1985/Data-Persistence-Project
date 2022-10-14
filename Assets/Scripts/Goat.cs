using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Goat : MonoBehaviour
{
    public static Goat Instance;
    public string playerName;
    public int highScore;
    public int score;
    public string bestPlayer;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);


    }


    [System.Serializable]

    class SaveData
    {
        public string savePlayer;
        public int saveScore;
    }

    public void SaveGoatData(string bestPlayer, int highScore)
    {
        SaveData data = new SaveData();
        data.saveScore = highScore;
        data.savePlayer = bestPlayer;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadGoatData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            bestPlayer = data.savePlayer;
            highScore = data.saveScore;
        }
    }

}
