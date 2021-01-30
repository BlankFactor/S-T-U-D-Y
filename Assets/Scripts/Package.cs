using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package : MonoBehaviour
{
    public List<GameObject> files;

    public bool randomTrashes = false;
    [Range(1, 20)]
    public int countOfTrashes = 20;

    private bool triggered = false;

    public GameObject trash;

    private void Start()
    {
        if (randomTrashes)
            countOfTrashes = Random.Range(1, countOfTrashes);
    }

    private void OnMouseDown()
    {
        if (triggered)
            return;

        triggered = true;

        while(files.Count != 0)
        {
            GameObject no = Instantiate(files[0], transform.position, transform.rotation);

            no.GetComponent<Rigidbody2D>().gravityScale = 1.0f;

            Vector2 v = new Vector2(Random.Range(-1, 1f), Random.Range(-1, 1f));
            no.GetComponent<Rigidbody2D>().AddForce(v * 5000.0f);
            files.RemoveAt(0);
        }
        while(countOfTrashes != 0)
        {
            GameObject no = Instantiate(trash, transform.position, transform.rotation);

           // if (gameObject.tag.Contains("System"))
           // {
            no.GetComponent<TrashFile>().GetTMP().text = TextReader.GetSystemName();
            Vector2 v = new Vector2(Random.Range(-1, 1f), Random.Range(-1, 1f));
            no.GetComponent<Rigidbody2D>().AddForce(v * 5000.0f);
            // }

            countOfTrashes--;
        }

        Destroy(gameObject);
    }


}
