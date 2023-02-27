using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameOverUIController : MonoBehaviour
{
    public Canvas parentCanvas;
    public Text congrats;
    public Text score;
    public Text obstaclesPassed;
    public Text timePassed;

    // Start is called before the first frame update
    void Start()
    {
        if (StatsController.isNewRecord)
        {
            StartCoroutine(ShowCongrats());            
        }

        score.text = $"Score: {StatsController.Score}";
        obstaclesPassed.text = $"Passed asteroids: {StatsController.ObstaclesPassed}";
        timePassed.text = $"Play time: {StatsController.TimePassed:hh}:{StatsController.TimePassed:mm}:{StatsController.TimePassed:ss}";
    }

    // Using coroutine to show Text object with delay
    IEnumerator ShowCongrats()
    {        
        yield return new WaitForSecondsRealtime(0.5f);
        congrats.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
