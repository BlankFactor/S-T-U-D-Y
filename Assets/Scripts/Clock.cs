using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Clock : MonoBehaviour
{
    public TextMeshPro number;
    public TextMeshPro colon;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 ms = GameManager.instance.GetMinAndSec();
        string text = "";

        if (ms.x <= 9)
            text += ("0" + ms.x);
        else
            text += ms.x;
        text += " ";
        if (ms.y <= 9)
            text += ("0" + ms.y);
        else
            text += ms.y;

        number.text = text;

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.gameStarted || !GameManager.instance.recordingTime)
            return;

        Vector2 ms = GameManager.instance.GetMinAndSec();
        string text = "";

        if (ms.x <= 9)
            text += ("0" + ms.x);
        else
            text += ms.x;
        text += " ";
        if (ms.y <= 9)
            text += ("0" + ms.y);
        else
            text += ms.y;

        number.text = text;
    }

  
}
