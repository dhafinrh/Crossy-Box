using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CarMovement : MonoBehaviour
{
    [SerializeField] float speed;
    Vector3 initialPosition;
    float disctanceLimit;

    public void setUpDistanceLimit(float disctance)
    {
        this.disctanceLimit = disctance;
    }

    private void Start()
    {
        initialPosition = this.transform.position;
    }
    private void Update()
    {
        speed = Random.Range(3, 5);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (Vector3.Distance(initialPosition, this.transform.position) > this.disctanceLimit)
        {
            Destroy(this.gameObject);
        }
    }

    // private int direction = 10;
    // private int carRotation = 90;
    // void Update()
    // {
    //     if (DOTween.IsTweening(transform))
    //     {
    //         return;
    //     }
    //     transform.DOMoveX(transform.position.x - direction, 3).SetEase(Ease.Linear).OnComplete(() =>
    //     {
    //         transform.DORotate(new Vector3(0, carRotation, 0), 1);
    //         direction = direction * -1;
    //         if (carRotation == 90)
    //         {
    //             carRotation += 180;
    //         }
    //         else
    //         {
    //             carRotation -= 180;
    //         }
    //     }); ;
    // }
}
