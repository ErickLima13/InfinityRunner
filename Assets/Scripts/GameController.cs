using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int Score;
    public int CoinScore;
    public int HighScore;
    public int HighScoreCoin;

    public Text scoreText;
    public Text CoinText;
    public Text RecordCoin;
    public Text RecordScore;
    public int ScorePerSecond;

    public GameObject GameOverPanel;
    public Button RestartBt;


    public static GameController current;
    public bool PlayerIsAlive;

    // Start is called before the first frame update
    void Start()
    {
        PlayerIsAlive = true;
        current = this;

        HighScore = PlayerPrefs.GetInt("HighScore");
        HighScoreCoin = PlayerPrefs.GetInt("HighScoreCoin");
    }

    float ScoreUpdated;
    // Update is called once per frame
    void Update()
    {
        if (PlayerIsAlive)
        {
            ScoreUpdated += ScorePerSecond * Time.deltaTime;
            Score = (int)ScoreUpdated;

            scoreText.text = Score.ToString();
        }

        RecordCoin.text = "Coins: " + HighScoreCoin.ToString();
        RecordScore.text = "Score: " + HighScore.ToString();
    }

    public void AddScore(int value)
    {
        if (PlayerIsAlive)
        {
            CoinScore += value;
            CoinText.text = CoinScore.ToString();
            Record();
        }
    }

    public void Record()
    {
        
        if (PlayerPrefs.GetInt("HighScore") < Score)
        {
            //Salva novo score
            PlayerPrefs.SetInt("HighScore", Score);
            HighScore = Score;
        }

        if (PlayerPrefs.GetInt("HighScoreCoin") < CoinScore)
        {
            PlayerPrefs.SetInt("HighScoreCoin", CoinScore);
            HighScoreCoin = CoinScore;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
