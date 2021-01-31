using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public AudioSource audio_Door;
    public AudioSource audio_FootStep;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetChecking_True()
    {
        Disrupter.instance.SetChecking_True();
    }
    public void SetChecking_False()
    {
        Disrupter.instance.SetChecking_False();
    }


    public void Play_Sound()
    {
        audio_Door.Play();
    }

    public void Play_Footstep()
    {
        audio_FootStep.Play();
    }
}
