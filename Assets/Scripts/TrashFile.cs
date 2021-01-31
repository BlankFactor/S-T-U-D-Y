using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrashFile : MonoBehaviour
{
    public TextMeshPro tmp;
    private SpriteRenderer sr;
    private Rigidbody2D rig2d;

    // Start is called before the first frame update
    void Start()
    {
        rig2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        string path = "Images/f";
        path += Random.Range(1, 8);
        sr.sprite = Resources.Load<Sprite>(path);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public TextMeshPro GetTMP()
    {
        return tmp;
    }

    private void OnMouseDrag()
    {
        if (GameManager.instance.pause || !GameManager.instance.gameStarted)
            return;

        Vector2 v2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rig2d.MovePosition(v2);
    }

    private void OnMouseUp()
    {
        if (GameManager.instance.pause || !GameManager.instance.gameStarted)
            return;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position, 0.3f);

        foreach (var i in colliders)
        {
            if (i.tag.Equals("Bin"))
            {
                Destroy(gameObject);
            }
        }
    }
}
