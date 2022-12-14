using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public GameObject GameOverText;

    private bool m_Started = false;
    public int m_Points;
   
    public Text bestScore;
    public Text currentPlayer;

    
    public string userName;

    private bool m_GameOver = false;

   
    private void Awake()
    {
        Instance = this;
        //Goat.Instance.LoadGoatData();

        //MenuManager.Instance.LoadPlayerName(userName);
    }
    // Start is called before the first frame update
    void Start()
    {


       

        
        //Goat.Instance.LoadGoatData();
        //Goat.Instance.LoadGoatName();
       // currentPlayer.text = MenuManager.Instance.userName.text;

       // bestScore.text = "Best Score: " + Goat.Instance.highScore + " " + "Player: " + currentPlayer.text;
        m_Points = 0;
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);

        int[] pointCountArray = new[] { 1, 1, 2, 2, 5, 5 };
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
       
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        Goat.Instance.score = m_Points;
        
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";

    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);
        BestScoreAlg();
        Goat.Instance.SaveGoatData(Goat.Instance.highScore);
        //Goat.Instance.SaveGoatName(currentPlayer.text);
        //_bestScore = m_Points;

    }

     public void BestScoreAlg()
    {
      if(Goat.Instance.score >= Goat.Instance.highScore)
        {
            Goat.Instance.bestPlayer = Goat.Instance.playerName;
            Goat.Instance.highScore = Goat.Instance.score;
        }
        Goat.Instance.SaveGoatName(Goat.Instance.bestPlayer);
    }


    public void SetBestPlayer()
    {
        if (MenuManager.Instance.userName == null && Goat.Instance.highScore == 0)
        {
            bestScore.text = "  ";
        }
        else
        {
            bestScore.text = "Best Score: " + Goat.Instance.bestPlayer + ": " + Goat.Instance.highScore;
        }
    }

    

}
    
