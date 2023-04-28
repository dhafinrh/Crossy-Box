using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class Movement : MonoBehaviour
{
    [SerializeField, Range(0, 1)] float moveDuration;
    [SerializeField, Range(0, 1)] float jumpHeight;
    [SerializeField] int leftMoveLimit;
    [SerializeField] int rightMoveLimit;
    [SerializeField] int backMoveLimit;

    public UnityEvent<Vector3> onJumped;
    public UnityEvent<int> onGetCoin;
    private bool isDie = false;

    void Update()
    {
        if (isDie == true)
            return;
        else

        if (DOTween.IsTweening(transform))
        {
            return;
        }

        Vector3 direction = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction += Vector3.forward;
            //transform.DOMoveZ(transform.position.z + 1, 0.2f);
            //transform.position += Vector3.forward;
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction += Vector3.back;
            //transform.DOMoveZ(transform.position.z - 1, 0.2f);
            //transform.position += Vector3.back;

        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction += Vector3.right;
            //transform.DOMoveX(transform.position.x + 1, 0.2f);
            //transform.position += Vector3.right;
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction += Vector3.left;
            //transform.DOMoveX(transform.position.x - 1, 0.2f);
            //transform.position += Vector3.left;
        }
        if (direction == Vector3.zero)
        {
            return;
        }
        Move(direction);
    }

    public void Move(Vector3 direction)
    {
        // transform.DOMoveZ(transform.position.z + direction.z, moveDuration);
        // transform.DOMoveX(transform.position.x + direction.x, moveDuration);

        Vector3 targetPosition = transform.position + direction;

        if (targetPosition.x < leftMoveLimit ||
            targetPosition.x > rightMoveLimit ||
            targetPosition.z < backMoveLimit ||
            Tree.PositionSet.Contains(targetPosition))
        {
            targetPosition = transform.position;
        }

        transform.DOJump(
            targetPosition,
            jumpHeight,
            1,
            moveDuration)
            .onComplete = BroadcastPositionOnJumped;

        transform.forward = direction;

        // var seq = DOTween.Sequence();
        // seq.Append(transform.DOMoveY(jumpHeight, moveDuration * 0.5f));
        // seq.Append(transform.DOMoveZ(0, moveDuration * 0.5f));
    }

    public void UpdateMoveLimit(int horizontalLimit, int backLimit)
    {
        leftMoveLimit = -horizontalLimit / 2;
        rightMoveLimit = horizontalLimit / 2;
        backMoveLimit = backLimit;
    }

    private void BroadcastPositionOnJumped()
    {
        onJumped.Invoke(transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {

            if (isDie == true)
                return;

            transform.DOScaleY(0.1f, 0.2f);

            isDie = true;
        }
        else if (other.CompareTag("Coin"))
        {
            var coin = other.GetComponent<Coin>();
            onGetCoin.Invoke(coin.Value);
            coin.Collected();
        }
    }
}
