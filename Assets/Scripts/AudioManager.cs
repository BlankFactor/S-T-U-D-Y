using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private AudioSource audio;

    public AudioClip sound_Click;
    public AudioClip sonud_FoundTarget;
    public AudioClip sound_Package;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play_Click()
    {
        audio.clip = sound_Click;
        audio.Play();
    }

    public void Play_FoundTarget()
    {
        audio.clip = sonud_FoundTarget;
        audio.Play();
    }

    public void Play_Package()
    {
        audio.clip = sound_Package;
        audio.Play();
    }
}
