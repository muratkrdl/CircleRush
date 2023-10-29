using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] Image gameOverPanel;
    [SerializeField] TextMeshProUGUI lastScoreText;

    int score;
    bool isGameOver;

    public bool IsGameOver
    {
        get
        {
            return isGameOver;
        }
    }

    void Awake() 
    {
        if(Instance == null) 
        {
            Instance = this;
        }   
        else
        {
            Destroy(gameObject);
        }

        scoreText.text = score.ToString();
        gameOverPanel.gameObject.SetActive(false);
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        gameOverPanel.gameObject.SetActive(true);
        lastScoreText.text = score.ToString();
        isGameOver = true;
    }

    public void ResetGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        isGameOver = false;
    }

}
