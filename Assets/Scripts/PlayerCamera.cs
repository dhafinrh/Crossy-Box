using UnityEngine;
using DG.Tweening;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField, Range(0, 1)] float moveDuration = 0.2f;
    private void Initiate()
    {
        offset = this.transform.position;
    }

    // Update is called once per frame
    public void UpdatePosition(Vector3 targetPost)
    {
        DOTween.Kill(this.transform);
        transform.DOMove(offset + targetPost, moveDuration);
    }

    public void Start()
    {
        
        transform.position = new Vector3(-2, 1, 2);
        transform.rotation = Quaternion.Euler(1.926f, 185.3f, 0);

        // Create a new Sequence
        Sequence mySequence = DOTween.Sequence();

        // Add a movement tween at the beginning
        mySequence.Append(transform.DOMove(new Vector3(1, 1, 1.5f), 2).SetEase(Ease.OutQuart));

        mySequence.Append(transform.DOMove(new Vector3(1, 1, 3), 0.5f).SetEase(Ease.InOutQuart));
        mySequence.Append(transform.DOMove(new Vector3(1, 1, 3), 0.5f));

        // Add another movement tween that will play after the first two tweens have completed
        mySequence.Append(transform.DORotate(new Vector3(44.633f, 341.7f, 0), 1));

        // Add a rotation tween that will play at the same time as the movement tween
        mySequence.Join(transform.DOMove(new Vector3(1.98f, 3.95f, -1.86f), 1));
        
        mySequence.OnComplete(Initiate);;

    }
}
