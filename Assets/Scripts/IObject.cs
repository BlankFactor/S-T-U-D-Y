using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IObject:MonoBehaviour
{
    private Rigidbody2D rig2d;
    void Start()
    {
        rig2d = GetComponent<Rigidbody2D>();
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
