using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrashFile : MonoBehaviour
{
    public TextMeshPro tmp;

    private Rigidbody2D rig2d;

    // Start is called before the first frame update
    void Start()
    {
        rig2d = GetComponent<Rigidbody2D>();
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
        Vector2 v2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rig2d.MovePosition(v2);
    }

    private void OnMouseUp()
    {
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
