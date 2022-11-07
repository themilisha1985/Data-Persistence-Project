using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class NewMenuManager : MonoBehaviour
{
    public string playerName;
    public TMP_InputField inputField;
    public TMP_Text HighScore;

    // Start is called before the first frame update
    void Start()
    {
        EliteList.Instance.LoadWinnerData();
        HighScore.text = "Best Score: " + EliteList.Instance.bestPlayer + ": " + EliteList.Instance.bestScore;

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SaveName()
    {
        playerName = inputField.text;
        EliteList.Instance.playerName = playerName;
    }
    public void StartMain()
    {
        SceneManager.LoadScene(1);

    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
       Application.Quit();
#endif
    }
}
