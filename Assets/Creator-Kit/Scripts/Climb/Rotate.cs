using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed = 30f;
    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.back, speed * Time.deltaTime);
    }
}
