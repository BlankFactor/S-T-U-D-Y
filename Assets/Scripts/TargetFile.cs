using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TargetFile : MonoBehaviour
{
    //[Header("Basic Attributes")]

    [Range(1, 5)]
    public int number;

    public string itemName;
    [TextArea]
    public string summary;
    public Sprite portrayal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (GameManager.instance.pause || !GameManager.instance.gameStarted)
            return;

        AudioManager.instance.Play_FoundTarget();
        GUIController.instance.SetDescription(this);
        GameManager.instance.FoundTarget(number);
        Destroy(gameObject);
    }
}
