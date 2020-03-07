﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int Score = 0;
    public Text ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = Score.ToString();
    }

    public int GetScore()
    {
        return Score;
    }

    public void IncreaseScore(int Increment)
    {
        Score += Increment;
    }
}
