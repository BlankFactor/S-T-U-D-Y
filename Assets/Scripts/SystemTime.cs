using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SystemTime : MonoBehaviour
{
    TextMeshPro tmp;

    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        string str = string.Empty;
        if (System.DateTime.Now.Hour < 10)
        {
            str += "0";
        }
        str += System.DateTime.Now.Hour;
        str += ":";
        if (System.DateTime.Now.Minute < 10)
        {
            str += "0";
        }
        str += System.DateTime.Now.Minute;
        tmp.text = str;
    }
}
