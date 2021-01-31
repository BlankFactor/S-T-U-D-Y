using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tick : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip sound_Tick;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play_Tick()
    {
        audio.clip = sound_Tick;
        audio.Play();
    }
}
