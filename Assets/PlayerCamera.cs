using UnityEngine;
using DG.Tweening;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField, Range(0, 1)] float moveDuration = 0.2f;
    private void Start()
    {
        offset = this.transform.position;
    }

    // Update is called once per frame
    public void UpdatePosition(Vector3 targetPost)
    {
        DOTween.Kill(this.transform);
        transform.DOMoveZ(offset.z + targetPost.z, moveDuration);
    }
}
