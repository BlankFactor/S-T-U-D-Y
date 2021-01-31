using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Game Releated")]
    public int countOfTargets;

    public float timeLimitation;

    public bool gameStarted = false ;
    public bool pause = true;

    [Header("Status(*DO NOT MODIFY*)")]
    public float current_Time;
    public float current_Time_Reverse;
    public int min;
    public int sec;

    [Header("Other Objects")]
    public Animator ani_Displayer;
    public GameObject cartoon_Victory;
    public GameObject cartoon_Fail;

    AudioSource audio_se;
    public AudioClip sound_victory;
    public AudioClip sound_gameover;


    private void Awake()
    {
        instance = this;

        min = (int)timeLimitation / 60;
        sec = (int)timeLimitation % 60;

        current_Time_Reverse = timeLimitation;
    }

    // Start is called before the first frame update
    void Start()
    {
        current_Time = 0;

        audio_se = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pause || !gameStarted)
            return;

        current_Time_Reverse -= Time.deltaTime;
        current_Time_Reverse = Mathf.Clamp(current_Time_Reverse, 0, timeLimitation);
        current_Time += Time.deltaTime;
        current_Time = Mathf.Clamp(current_Time, 0, timeLimitation);

        min = (int)current_Time_Reverse / 60;
        sec = (int)current_Time_Reverse % 60;

        min = Mathf.Clamp(min, 0, 60);
        sec = Mathf.Clamp(sec, 0, 60);

        if (current_Time.Equals(timeLimitation)){
            gameStarted = false;
            Failed();
        }
    }

    void Play_Gameover()
    {
        audio_se.clip = sound_gameover;
        audio_se.Play();
    }
    void Play_Victory()
    {
        audio_se.clip = sound_victory;
        audio_se.Play();
    }

    public void StartGame()
    {
        if (!gameStarted)
        {
            gameStarted = true;
            PlayerController.instance.gameObject.SetActive(true);
            ani_Displayer.SetBool("Booting", true);
            PlayerController.instance.isSearching = true;
        }
    }

    public void Victory()
    {
        gameStarted = false;
        pause = false;

        cartoon_Victory.SetActive(true);
        Play_Victory();
    }

    public void Failed()
    {
        gameStarted = false;
        pause = false;

        cartoon_Fail.SetActive(true);
        Play_Gameover();
    }
    
    public void FoundTarget(int _number)
    {
        countOfTargets--;
        GUIController.instance.LightSketch(_number);

        if(countOfTargets == 0)
        {
            gameStarted = false;
            Victory();
        }
    }

    public void SetPause(bool _v)
    {
        pause = _v;
    }

    public Vector2 GetMinAndSec()
    {
        return new Vector2(min, sec);
    }
}
