using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour
{
    private Text score, strikes;
    private bool scored, strike;
    private int _score, _strikes;

    public static GamePlayManager Instance { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("ScoreText").GetComponent<Text>();
        strikes = GameObject.Find("StrikesText").GetComponent<Text>();

        scored = false;
        strike = false;

        _score = 0;
        _strikes = 0;
    }

    // Update is called once per frame
    void Update()
    {
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
}