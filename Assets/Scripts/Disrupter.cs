using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disrupter : MonoBehaviour
{
    public static Disrupter instance;

    public Vector2 range_Duration;
    public Vector2 range_NextEvent;

    [Header("Status")]
    public bool checking = false;
    public bool inEvent = false;

    public float timer;

    public Animator ani_Door;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(range_NextEvent.x, range_NextEvent.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.gameStarted || GameManager.instance.pause)
            return;

        // ׼���¼� ȷ����һ���¼�
        if(!checking && !inEvent)
        {
            // ����Ԥ��״̬
            if(timer == 0)
            {
                // ׼��ʱ�� 2 ��
                timer = Random.Range(range_Duration.x, range_Duration.y);

                Debug.Log("���׼������");
                inEvent = true;
                ani_Door.SetBool("Activate", true);
            }
            else
            {
                timer -= Time.deltaTime;
                timer = Mathf.Clamp(timer, 0, 10000);
            }

            return;
        }

        if (checking && inEvent)
        {
            // �����
            if (timer == 0)
            {
                ani_Door.SetBool("Activate", false);
                timer = Random.Range(range_NextEvent.x, range_NextEvent.y);
                checking = false;
            }
            else
            {
                if (PlayerController.instance.isSearching)
                {
                    GameManager.instance.Failed();
                    Debug.Log("�㱻������");
                }

                timer -= Time.deltaTime;
                timer = Mathf.Clamp(timer, 0, 10000);
            }
        }
    }

    public void SetChecking_True()
    {
        checking = true;
    }

    public void SetChecking_False()
    {
        checking = false;
        inEvent = false;
    }
}
