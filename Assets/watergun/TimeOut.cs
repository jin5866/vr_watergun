using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOut : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    float DestroyDuration = 10f;
    float startTime;
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime > DestroyDuration) Destroy(gameObject);
    }
}
