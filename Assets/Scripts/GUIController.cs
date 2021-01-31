using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    public static GUIController instance;

    [Header("Configuration")]
    public List<Image> sketches;
    public GameObject btn_Start;

    [Header("Other Objects")]
    public ItemDescription panel_ItemDescrption;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LightSketch(int _number)
    {
        sketches[_number - 1].GetComponent<Image>().color = Color.white;
    }

    public void ChangeColor()
    {
        if (GameManager.instance.gameStarted)
        {
            btn_Start.GetComponent<Image>().color = Color.red;
        }
    }

    public void SetDescription(TargetFile _t)
    {
        GameManager.instance.pause = true;
        panel_ItemDescrption.SetDescription(_t);
        panel_ItemDescrption.gameObject.SetActive(true);
    }
}
