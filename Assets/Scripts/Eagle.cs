using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Eagle : MonoBehaviour
{
    //[SerializeField, Range(0, 20)] float speed;

    public void EagleMove(Vector3 bisonPosition)
    {
        Debug.Log("EagleMoves!");
        Vector3 currentPosition = bisonPosition + new Vector3(0, 1, 0);
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(currentPosition, 2f).SetEase(Ease.OutQuart));
        sequence.Append(transform.DOLocalMove(currentPosition + new Vector3(0, 10, 15), 3f).SetEase(Ease.OutBounce));

        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
