using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayManager : MonoBehaviour
{
    private Text score, strikes, timer;
    private int _score, _strikes;
    
    public Canvas grillCanvas;

    public Text gameOverText;
    public Button gameOverButton;

    public const int MAX_STRIKES = 3;
    public const int MAX_SCORE = 5;

    public static GamePlayManager Instance { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("ScoreText").GetComponent<Text>();
        strikes = GameObject.Find("StrikesText").GetComponent<Text>();
        timer = GameObject.Find("TimerText").GetComponent<Text>();
        grillCanvas = GameObject.Find("GrillCanvas").GetComponent<Canvas>();

        grillCanvas.enabled = false;

        gameOverText.enabled = false;
        gameOverButton.gameObject.SetActive(false);

        _score = 0;
        _strikes = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (_strikes == 3)
        {
            SceneManager.LoadScene("Game Over");

        }
    }

    private void Awake()
    {
        Instance = this;
    }

    public int GetScore()
    {
        return _score;
    }

    public void Score()
    {
        _score++;
        score.text = "Score: " + _score;
        if (_score >= 5)
        {
            GameOver(true);
        }
    }

    public void Strike()
    {
        _strikes++;
        strikes.text = "Strikes: " + _strikes;
        if (_strikes >= 3)
        {
            GameOver(false);
        }
    }

    public void Time(float time)
    {
        timer.text = $"Time Left: {time:0.##}s";
    }

    public void ToggleMenu()
    {
        if (grillCanvas.isActiveAndEnabled)
        {
            grillCanvas.enabled = false;
        } 
        else
        {
            grillCanvas.enabled = true;
        }
    }

    void GameOver(bool victory)
    {
        if (victory)
        {
            gameOverText.text = "You won!";
        } else
        {
            gameOverText.text = "Game Over!";
        }

        gameOverText.enabled = true;
        gameOverButton.gameObject.SetActive(true);
        UnityEngine.Time.timeScale = 0;
    }
}
