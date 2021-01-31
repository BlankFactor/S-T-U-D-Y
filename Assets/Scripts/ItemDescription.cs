using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemDescription : MonoBehaviour
{
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI summary;
    public Image portrayal;

    public bool interactable = false;

    public void SetDescription(TargetFile _tf)
    {
        itemName.text = "¡¶" + _tf.itemName + "¡·";
        summary.text = _tf.summary;
        portrayal.sprite = _tf.portrayal;
    }

    private void OnEnable()
    {
        Invoke("Delay", 0.2f);
    }

    private void Update()
    {
        if (!GameManager.instance.pause)
            return;

        if ((Input.GetMouseButtonDown(0) && interactable))
        {
            GameManager.instance.pause = false;
            gameObject.SetActive(false);
            interactable = false;
        }
    }

    void Delay()
    {
        interactable = true;
    }
}
