using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFile : MonoBehaviour
{
    //[Header("Basic Attributes")]

    [Range(1, 5)]
    public int number;

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
        GameManager.instance.FoundTarget(number);
        Destroy(gameObject);
    }
}
