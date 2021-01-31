using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TextReader
{
    public static string GetSystemName()
    {
        TextAsset txt = Resources.Load("SystemNameList") as TextAsset;

        string[] str = txt.text.Split('\n');

        return str[Random.Range(0,str.Length)];
    }

    public static string GetName()
    {
        TextAsset txt = Resources.Load("NameList") as TextAsset;

        string[] str = txt.text.Split('\n');

        return str[Random.Range(0, str.Length)];
    }
}
