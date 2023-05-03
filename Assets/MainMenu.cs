using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        DOTween.KillAll();
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        PlayerPrefs.Save();
        Application.Quit();
    }
}
