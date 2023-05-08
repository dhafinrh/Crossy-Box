using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EagleSpawner : MonoBehaviour
{
    [SerializeField] Eagle eagle;
    [SerializeField] Movement bison;
    [SerializeField] float initialTimer = 7;
    float timer;
    bool spawnEagle = false;
    public UnityEvent<Vector3> onSpawnEagle;

    public float InitialTimer { get => initialTimer;}

    void Start()
    {
        timer = initialTimer;
        eagle.gameObject.SetActive(value: false);
    }
    void Update()
    {
        if (timer <= 0 && eagle.gameObject.activeInHierarchy == false && spawnEagle == false)
        {
            eagle.transform.position = bison.transform.position + new Vector3(0, 5, -5);
            eagle.gameObject.SetActive(true);
            bison.SetMoveAble(false);
            onSpawnEagle.Invoke(bison.transform.position);
            spawnEagle = true;

        }

        timer -= Time.deltaTime;
    }

    public void ResetTimer()
    {
        timer = initialTimer;
    }
}
