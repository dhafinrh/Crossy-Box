using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] private TMP_Text currentTimeText;
    [SerializeField] EagleSpawner eagleSpawner;
    [SerializeField] Image healthbar;
    bool stopWatchActive = false;
    float currentTime;
    float life;
    bool gamestart = false;
    public UnityEvent<float> OnTimeUpdate;
    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    private void OnEnable()
    {
        currentTime = 0;
        life = eagleSpawner.InitialTimer;
    }
    private void Update()
    {
        if (stopWatchActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();

        if (gamestart)
        {
            life -= Time.deltaTime;
            healthbar.fillAmount = 0 + Mathf.Clamp01(life / eagleSpawner.InitialTimer);
        }
    }
    public void GameStart()
    {
        gamestart = true;
    }
    public void ResetLife()
    {
        life = eagleSpawner.InitialTimer;
    }

    public void Dead()
    {
        gamestart = false;
        healthbar.fillAmount = 0;
    }

    public void StartStopwatch()
    {
        stopWatchActive = true;
    }
    public void StopStopwatch()
    {
        if (stopWatchActive == true)
        {
            stopWatchActive = false;
            OnTimeUpdate.Invoke(currentTime);
        }
        else
        {
            return;
        }
    }
}
