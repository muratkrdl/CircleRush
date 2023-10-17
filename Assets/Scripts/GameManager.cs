using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] TextMeshProUGUI scoreText;

    int score;

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
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void ResetGame()
    {
        StartCoroutine(RLevel());
    }

    IEnumerator RLevel()
    {
        yield return new WaitForSeconds(1.25f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
