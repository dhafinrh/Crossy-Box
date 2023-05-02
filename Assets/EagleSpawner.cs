using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleSpawner : MonoBehaviour
{
    [SerializeField] Eagle eagle;
    [SerializeField] Movement bison;
    [SerializeField] float initialTimer = 7;
    float timer;

    void Start()
    {
        timer = initialTimer;
        eagle.gameObject.SetActive(false);
    }
    void Update()
    {
        if (timer <= 0 && eagle.gameObject.activeInHierarchy == false)
        {
            eagle.transform.position = bison.transform.position + new Vector3(0, 1, -5);
            eagle.gameObject.SetActive(true);
            bison.SetMoveAble(false);
        }
        timer -= Time.deltaTime;
        Debug.Log("SISA WAKTU : " + timer);
    }

    public void ResetTimer()
    {
        Debug.Log("RESET");
        timer = initialTimer;
    }
}
