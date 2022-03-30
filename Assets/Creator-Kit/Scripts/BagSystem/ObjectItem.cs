using UnityEngine;
using System.Collections;

public class ObjectItem : MonoBehaviour
{

    public string objId;
    public string objName;
    public int count;
    public string note;
    public int level;
    public bool isCanAdd;
    public int maxAdd;

    public bool isChecked;

    // Use this for initialization
    void Start()
    {
        isChecked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isChecked)
        {
            GetComponent<SpriteRenderer>().material.color = Color.red;
        }
        else
        {
            GetComponent<SpriteRenderer>().material.color = Color.white;
        }
        isChecked = false;
    }
}