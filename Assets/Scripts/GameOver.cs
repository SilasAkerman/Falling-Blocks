using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Allows for the Text object
using UnityEngine.SceneManagement; 

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Text secondsSurviveUI;
    public Text higscoreUI;

    bool gameOver;
    int highscore;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<PlayerController>().OnPlayerDeath += OnGameOver;
        highscore = PlayerPrefs.GetInt("High Score");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    void OnGameOver()
    {
        gameOverScreen.SetActive(true);
        int score = Mathf.RoundToInt(Time.timeSinceLevelLoad);
        secondsSurviveUI.text = score.ToString();
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("High Score", score);
        }
        higscoreUI.text = "Highscore: " + highscore.ToString();
        gameOver = true;
    }
}
