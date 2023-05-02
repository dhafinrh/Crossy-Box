using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    [SerializeField] private int value;
    [SerializeField, Range(0, 10)] private int rotationSpeed = 1;

    public int Value { get => value; }

    public void Collected()
    {
        GetComponent<Collider>().enabled = false;

        this.transform.DOLocalJump(
            this.transform.position,
            2,
            1,
            0.5f
        ).onComplete = SelfDestruct;
    }

    private void SelfDestruct()
    {
        Destroy(this.gameObject);
    }

    void Update()
    {
        transform.Rotate(0, 180 * rotationSpeed * Time.deltaTime, 0);
    }
}
