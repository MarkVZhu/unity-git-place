using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove: MonoBehaviour
{
    private bool startCheck; 
    public int index = 0;                       //�ӳ�ʼλ�ô���
    public float speed = 3.0f;                 //�ƶ��ٶ�
    public Transform[] theWayPoints;            //�ƶ�Ŀ�����
    // Start is called before the first frame update
    void Start()
    {
        startCheck = GameObject.Find("Capsule").GetComponent<PlatformStartMove>().startMove;
    }
    // Update is called once per frame
    void Update()
    {
        startCheck = GameObject.Find("Capsule").GetComponent<PlatformStartMove>().startMove;
        if (startCheck)
        {
            //δ�ﵽָ����indexλ�ã�����MoveToThePoints����ÿ֡�����ƶ�
            if (transform.position != theWayPoints[index].position)
            {
                MoveToThePoints();
            }
            //��������ָ��indexλ��,�ı�indexֵ������ѭ��
            else
            {
                if (index == theWayPoints.Length - 1)
                    Destroy(this);
                index++;
            }
        }
        
    }
    void MoveToThePoints()
    {
        //�ӵ�ǰλ�ð���ָ���ٶ��Ƶ�indexλ�ã��ǵ�speed * Time.deltaTime����Ȼ��˲��
        Vector2 temp = Vector2.MoveTowards(transform.position, theWayPoints[index].position, speed * Time.deltaTime);
        GetComponent<Rigidbody2D>().MovePosition(temp);

    }
}

