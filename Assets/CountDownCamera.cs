using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CountDownCamera : MonoBehaviour
{
    public void Initiate()
    {
        transform.position = new Vector3(-1, 1, 2);
        transform.rotation = Quaternion.Euler(1.926f, 185.3f, 0);

        // Create a new Sequence
        Sequence mySequence = DOTween.Sequence();

        // Add a movement tween at the beginning
        mySequence.Append(transform.DOMove(new Vector3(1, 1, 2), 1).SetEase(Ease.OutQuart));

        mySequence.Append(transform.DOMove(new Vector3(1, 1, 3), 0.5f).SetEase(Ease.InOutQuart));
        mySequence.Append(transform.DOMove(new Vector3(1, 1, 3), 0.5f));

        // Add another movement tween that will play after the first two tweens have completed
        mySequence.Append(transform.DORotate(new Vector3(44.633f, 341.7f, 0), 1));

        // Add a rotation tween that will play at the same time as the movement tween
        mySequence.Join(transform.DOMove(new Vector3(1.98f, 8.69f, -4.42f), 1));
    }
}
