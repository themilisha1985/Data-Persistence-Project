using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public InputField playerInput;
    public Text userName;


    private void Awake()
    {
        //if (Instance != null)
        //{
        //    Destroy(Instance);
        //}
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       userName.text = playerInput.text;

        //EnterPlayerName();


    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
        
    }

    public void SaveNameClicked()
    {
        //userName.text = playerInput.text;

        //Goat.Instance.SaveGoatName(userName.text);

        //Goat.Instance.bestPlayer = userName.text;
        SavePlayerName(userName.text);
        
    }
    //public void EnterPlayerName()
    //{
    //    if (playerInput.text == null)
    //    {
    //        Goat.Instance.LoadGoatData();
    //        Goat.Instance.bestPlayer = userName.text;
    //    }
    //    else
    //    {
    //        Goat.Instance.bestPlayer = userName.text;
    //    }
    //
    //}

    //    [System.Serializable]

        class SaveData
    {
        public string userName;
    }

    public void SavePlayerName(string userName)
    {
        SaveData data = new SaveData();
        data.userName = userName;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayerName(string userName)
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            userName = data.userName;
        }
    }





    //if (Input.GetKeyDown(KeyCode.Return))
    //{
    //    Goat.Instance.bestPlayer = userName.text;


    //}
}

