using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using TMPro;

public class PlayCountdown : MonoBehaviour
{
    [SerializeField] TMP_Text countdown;
    public UnityEvent onStart;
    public UnityEvent onEnd;

    private void Start()
    {
        onStart.Invoke();
        var sequence = DOTween.Sequence();
        countdown.transform.localScale = Vector3.zero;
        countdown.text = "3";

        sequence.Append(countdown.transform.DOScale(
        Vector3.one,
        1f).OnComplete(() =>
        {
            countdown.transform.localScale = Vector3.zero;
            countdown.text = "2";
        }));
        sequence.Append(countdown.transform.DOScale(
            Vector3.one,
            1f).OnComplete(() =>
            {
                countdown.transform.localScale = Vector3.zero;
                countdown.text = "1";
            }));
        sequence.Append(countdown.transform.DOScale(
        Vector3.one,
        1f).OnComplete(() =>
        {
            countdown.transform.localScale = Vector3.zero;
            countdown.text = "GO!";
        }));
        sequence.Append(countdown.transform.DOScale(
            Vector3.one,
            1f).OnComplete(() =>
            {
                onEnd.Invoke();
            }));
    }
}
