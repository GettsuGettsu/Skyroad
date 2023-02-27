using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsController : MonoBehaviour
{
    private static int scoreValue;
    private static int highScoreValue;
    private static int obstaclesPassedValue;
    private static TimeSpan timePassedValue;

    public GameObject player;
    public Text score;
    public Text highScore;
    public Text obstaclesPassed;
    public Text timePassed;
    public static bool isNewRecord = false;

    public static int Score { get { return scoreValue; } }
    public static int ObstaclesPassed { get { return obstaclesPassedValue; } }
    public static TimeSpan TimePassed { get { return timePassedValue; } }

    void Start()
    {
        InitializeStats();
    }

    void Update()
    {
        timePassedValue = new TimeSpan(0, 0, Mathf.RoundToInt(Time.timeSinceLevelLoad));

        score.text = $"Score: {scoreValue}";
        highScore.text = $"Record: {highScoreValue}";
        obstaclesPassed.text = $"Passed asteroids: {obstaclesPassedValue}";
        timePassed.text = $"Play time: {timePassedValue:hh}:{timePassedValue:mm}:{timePassedValue:ss}";
    }

    private void InitializeStats()
    {
        LoadRecord();
        scoreValue = 0;
        obstaclesPassedValue = 0;
        timePassedValue = TimeSpan.Zero;
        InvokeRepeating(nameof(IncreaseScore), .5f, 1);
    }

    private void IncreaseScore()
    {
        scoreValue += (int)ShipController.moveSpeedMultiplier;
    }

    public static void IncreaseScoreObstacle()
    {
        scoreValue += 5;
        obstaclesPassedValue += 1;
    }

    public static void LoadRecord()
    {
        highScoreValue = SaveController.Load("_HighScore");
    }

    public static void CheckRecord()
    {
        if (scoreValue > highScoreValue)
        {
            isNewRecord = true;
            highScoreValue = scoreValue;
            SaveController.Save("_HighScore", highScoreValue);
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        GameObjectsHelper.FindInactiveObjectByTag("Pause").SetActive(true);
    }
}
