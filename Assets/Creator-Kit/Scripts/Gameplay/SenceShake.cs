using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenceShake : MonoBehaviour
{
    private Vector3 shakePos = Vector3.zero;
    private float shakeTime = 40.0f;
    // Use this for initialization
    void Start()
    {

    }

  
    void Update()
    {
        if (shakeTime>0)
        {
            transform.localPosition -= shakePos;
            shakePos = Random.insideUnitSphere / 3.0f;
            transform.localPosition += shakePos;
            shakeTime -= 1.0f;
        }
    }
}