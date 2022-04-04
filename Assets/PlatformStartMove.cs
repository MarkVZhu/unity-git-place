using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformStartMove : MonoBehaviour
{
    public bool startMove = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            startMove = true;
    }
}
