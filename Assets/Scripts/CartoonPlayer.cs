using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CartoonPlayer : MonoBehaviour
{
    Image ima;

    public List<Sprite> images;
    bool restartable = false;

    // Start is called before the first frame update
    void Start()
    {
        ima = GetComponent<Image>();

        ima.sprite = images[0];
        images.RemoveAt(0);
    }

    private void Update()
    {
    }

    public void Change()
    {
        if(images.Count == 0)
        {
            if (gameObject.tag != "ED")
            {
                Destroy(gameObject);
            }
            else{
                restartable = true;
            }


            if (restartable)
            {
                SceneManager.LoadScene(0);
            }

            return;
        }

        ima.sprite = images[0];
        images.RemoveAt(0);
    }
}
