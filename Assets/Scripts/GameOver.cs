using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TMP_Text gameOverText;
    private float finalTime;
    private int score;
    private TimeSpan time;

    public void UpdateTime(float value)
    {
        finalTime = value;
        time = TimeSpan.FromSeconds(finalTime);
        UpdateResult();
    }
    public void UpdateScore(int value)
    {
        score = value;
    }
    private void UpdateResult()
    {
        gameOverText.text = "GAME OVER!\nScore : " + score + "\nTime : " + time.Minutes.ToString() + ":" + time.Seconds.ToString();;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        SceneManager.LoadScene("Main");

    }
}
