using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Folder : MonoBehaviour
{
    public enum Direction
    {
        Up,
        None,
        Down
    }

    public enum FileType
    {
        Trash,
        Folder,
        Disk,
        Special,
        Package
    }

    [Header("Basic Attributes")]
    public Direction cur_Direction = Direction.None;
    public Direction last_Direction = Direction.None;
    public FileType fileType = FileType.Trash;

    public bool randomTrashes = false;
    [Range(0, 30)]
    public int CountOfTrashes;

    public List<GameObject> files;
    public GameObject trash;

    [Header("Status")]
    private float lastY;
    private float currentY;

    public bool canPop = false;
    public bool onDrag = false;
    public bool clicked = false;
    public bool cleared = false;

    [Header("Gizmos Setting")]
    public Vector2 spawnArea = Vector2.zero;

    private Rigidbody2D rig2d;

    // Start is called before the first frame update
    void Start()
    {
        rig2d = GetComponent<Rigidbody2D>();

        OnMouseUp();

        if (randomTrashes)
        {
            CountOfTrashes = Random.Range(1, CountOfTrashes);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (onDrag)
        {
            if (cur_Direction != Direction.None)
            {
                last_Direction = cur_Direction;
            }

            lastY = currentY;
            currentY = transform.position.y;
            if (currentY.Equals(lastY))
            {
                cur_Direction = Direction.None;
            }
            else if (currentY > lastY)
            {
                cur_Direction = Direction.Up;
            }
            else
                cur_Direction = Direction.Down;

            if (last_Direction == Direction.Up && cur_Direction == Direction.Down)
            {
                canPop = true;
                cur_Direction = Direction.None;
                last_Direction = Direction.None;
            }
        }
    }

    private void FixedUpdate()
    {
        if (canPop && onDrag)
        {
            canPop = false;
            PopFile();
        }
    }

    private void OnMouseDrag()
    {
        if (GameManager.instance.pause || !GameManager.instance.gameStarted)
            return;

        Vector2 v2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rig2d.MovePosition(v2);

        if (!clicked)
        {
            clicked = true;
            rig2d.gravityScale = 1;
        }
    }

    private void OnMouseDown()
    {
        if (GameManager.instance.pause || !GameManager.instance.gameStarted)
            return;

        lastY = currentY = transform.position.y;
        canPop = false;
        onDrag = true;
        cur_Direction = last_Direction = Direction.None;
    }

    private void OnMouseUp()
    {
        if (GameManager.instance.pause || !GameManager.instance.gameStarted)
            return;

        canPop = false;
        onDrag = false;
        lastY = currentY = 0;
        cur_Direction = last_Direction = Direction.None;

        if (cleared)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position, 0.1f);

            foreach(var i in colliders)
            {
                if (i.tag.Equals("Bin"))
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    void PopFile()
    {
        if (files.Count == 0 && CountOfTrashes == 0)
        {
            cleared = true;
            return;
        }

        float probability = Random.Range(0, 1f);
        // 弹出特殊文件或文件夹
        if ((files.Count != 0 && probability <= 0.5f) || CountOfTrashes == 0)
        {
            GameObject no = Instantiate(files[0], transform.position + (Vector3)spawnArea, transform.rotation);

            if (no.tag.Contains("Floder"))
                no.GetComponent<Rigidbody2D>().gravityScale = 1.0f;

            no.transform.localScale = new Vector3(1, 1, 1);
            files.RemoveAt(0);
        }
        else if ((CountOfTrashes != 0 && probability > 0.5f) || files.Count == 0)
        {
            GameObject no = Instantiate(trash, transform.position + (Vector3)spawnArea, transform.rotation);

            if (gameObject.tag.Contains("System"))
            {
                no.GetComponent<TrashFile>().GetTMP().text = TextReader.GetSystemName();
            }
            else
            {
                no.GetComponent<TrashFile>().GetTMP().text = TextReader.GetName();
            }

            no.transform.localScale = new Vector3(1, 1, 1);
            CountOfTrashes--;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere((Vector2)transform.position + spawnArea, 0.05f);
    }
}