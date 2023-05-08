using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    private void OnEnable()
    {
        canvasGroup.transform.position = new Vector3(-1060, 540, 0);
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        Sequence sequence = DOTween.Sequence();
        sequence.Append(canvasGroup.transform.DOLocalMoveX(-960, 1f).SetEase(Ease.OutQuart));
        sequence.Join(canvasGroup.DOFade(1, 1f).OnComplete(() =>
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }));
    }

    public void Kill()
    {
        DOTween.KillAll();
    }

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
