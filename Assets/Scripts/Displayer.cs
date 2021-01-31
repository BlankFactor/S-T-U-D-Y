using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Displayer : MonoBehaviour
{
    public GameObject clock;

    private AudioSource audio;
    public AudioClip sound_Startup;

    public AudioSource audio_Fan;
    public AudioClip sound_Fan;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartRecording()
    {
        GameManager.instance.SetPause(false);
        clock.SetActive(true);
    }

    public void Play_Startup()
    {
        audio.clip = sound_Startup;
        audio.Play();
    }

    public void Play_Fan()
    {
        audio_Fan.Play();
    }
}