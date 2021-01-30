using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disrupter : MonoBehaviour
{
    public static Disrupter instance;

    public Vector2 range_Duration;
    public float time_Duration;

    public Vector2 range_NextEvent;
    public float time_nextEvent;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        time_Duration = Random.Range(range_Duration.x, range_Duration.y);
        time_nextEvent = Random.Range(range_NextEvent.x, range_NextEvent.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.gameStarted || !GameManager.instance.recordingTime)
            return;
    }
}
