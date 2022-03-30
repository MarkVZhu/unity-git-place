using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    private Transform tr;
    //背包类
    private Pack pack;

    // Use this for initialization
    void Start()
    {
        tr = GetComponent<Transform>();
        pack = GetComponent<Pack>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.B))
        {
            pack.showPack();
        }

        Debug.DrawRay(tr.position, tr.forward * 2.0f, Color.green);
        RaycastHit hit;
        if (Physics.Raycast(tr.position, tr.forward, out hit, 2.0f))
        {
            //Debug.Log ("射线击中:" + hit.collider.gameObject.name + "\n tag:" + hit.collider.tag);
            GameObject gameObj = hit.collider.gameObject;
            ObjectItem obj = (ObjectItem)gameObj.GetComponent<ObjectItem>();
            if (obj != null)
            {
                obj.isChecked = true;
                //Debug.Log(obj.objName);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    obj = pack.getItem(obj);
                    if (obj.count == 0)
                    {
                        //gameObj.SetActive(false);
                        Destroy(gameObj);
                    }
                }
            }
        }
    }
}