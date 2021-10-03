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

    private const int MAX_STRIKES = 3;

    public static GamePlayManager Instance { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("ScoreText").GetComponent<Text>();
        strikes = GameObject.Find("StrikesText").GetComponent<Text>();
        timer = GameObject.Find("TimerText").GetComponent<Text>();

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

    public void Score()
    {
        _score++;
        score.text = "Score: " + _score;
    }

    public void Strike()
    {
        _strikes++;
        strikes.text = "Strikes: " + _strikes;
    }

    public void Time(float time)
    {
        timer.text = $"Time Left: {time:0.##}s";
    }
}
