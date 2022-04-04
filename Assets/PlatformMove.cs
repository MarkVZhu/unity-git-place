using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove: MonoBehaviour
{
    private bool startCheck; 
    public int index = 0;                       //从初始位置触发
    public float speed = 3.0f;                 //移动速度
    public Transform[] theWayPoints;            //移动目标点组
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
            //未达到指定的index位置，调用MoveToThePoints函数每帧继续移动
            if (transform.position != theWayPoints[index].position)
            {
                MoveToThePoints();
            }
            //到了数组指定index位置,改变index值，不断循环
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
        //从当前位置按照指定速度移到index位置，记得speed * Time.deltaTime，不然会瞬移
        Vector2 temp = Vector2.MoveTowards(transform.position, theWayPoints[index].position, speed * Time.deltaTime);
        GetComponent<Rigidbody2D>().MovePosition(temp);

    }
}

