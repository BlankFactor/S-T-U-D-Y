using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    private SpriteRenderer sr;
    public List<Sprite> sprites;

    public float interVal;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        timer = interVal;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer == 0)
        {
            timer = interVal;

            sr.sprite = sprites[Random.Range(0, sprites.Count)];
        }
        else
        {
            timer -= Time.deltaTime;
            timer = Mathf.Clamp(timer, 0, 1000);
        }
    }
}
