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
        str += System.DateTime.Now.Hour + ":" + System.DateTime.Now.Minute;
        tmp.text = str;
    }


}
