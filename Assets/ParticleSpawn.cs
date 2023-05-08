using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawn : MonoBehaviour
{
    [SerializeField] private ParticleSystem sparks;
    [SerializeField] private float minInterval;
    [SerializeField] private float maxInterval;

    void OnEnable()
    {
        StartCoroutine(SparksCoroutine());
    }

    IEnumerator SparksCoroutine()
    {
        while (true)
        {
            // Wait for a random interval
            float interval = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(interval);

            // Emit a burst of sparks
            sparks.Play();
        }
    }
}
