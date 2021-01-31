using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [Header("Status")]
    public bool isSearching = true;

    [Header("Other Objects")]
    public Animator atr_disguisedWindow;
    public SpriteRenderer icon;
    public Sprite icon_Selected;
    public Sprite icon_Unselected;

    private void Awake()
    {
        instance = this;
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.gameStarted || GameManager.instance.pause)
        {
            return;
        }

        if (Input.GetMouseButton(1))
        {
            SetSearching(false);
        }else if (!Input.GetMouseButton(1))
        {
            SetSearching(true);
        }
    }

    void SetSearching(bool _v)
    {
        if (_v == isSearching)
            return;

        if (_v)
        {
            isSearching = _v;
            atr_disguisedWindow.SetBool("Disguised", false);
            icon.sprite = icon_Unselected;
        }
        else
        {
            isSearching = _v;
            atr_disguisedWindow.SetBool("Disguised", true);
            icon.sprite = icon_Selected;
        }
    }
}
