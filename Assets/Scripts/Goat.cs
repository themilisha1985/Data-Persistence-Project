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

       if (MenuManager.Instance.playerInput != null)
       {
         playerName = MenuManager.Instance.playerInput.text;
       }
       else
       {
           bestPlayer = playerName;
       }
    }
    private void Start()
    {
        
    }
    //public void CheckBestPlayer()
    //{
    //    if (Goat.Instance.score >= Goat.Instance.highScore)
    //    {
    //        Goat.Instance.bestPlayer = Goat.Instance.playerName;
    //        Goat.Instance.highScore = Goat.Instance.score;
    //    }
    //    Goat.Instance.SaveGoatData(Goat.Instance.bestPlayer, Goat.Instance.highScore);

    //}

    

    [System.Serializable]

    class SaveData
    {
        public string savePlayer;
        public int saveScore;
    }

    public void SaveGoatData(int highScore)
    {
        SaveData data = new SaveData();
        data.saveScore = highScore;
        
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void SaveGoatName(string playerName)
    {
        SaveData data = new SaveData();
        data.savePlayer = bestPlayer ;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadGoatData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            
            highScore = data.saveScore;
        }
    }

    public void LoadGoatName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            bestPlayer = data.savePlayer;
            
        }
    }

    
}
